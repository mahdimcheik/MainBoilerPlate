using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MainBoilerPlate.Models
{

    public class Sort
    {
        public string Field { get; set; }
        public int Order { get; set; }
    }

    public class FilterItem
    {
        public required object Value { get; set; }
        public required string MatchMode { get; set; }
    }

    public class DynamicFilters<T>
    {
        public int First { get; set; }
        public int Rows { get; set; }
        public string? Search { get; set; }
        public string GlobalSearch { get; set; }
        public List<Sort> sorts { get; set; }
        public Dictionary<string, FilterItem> Filters { get; set; } = new();
    }

    public static class FilterExtensions
    {
        public static IQueryable<T> ApplySorts<T>(
            this IQueryable<T> query,
            DynamicFilters<T> dynamicFilters
        )
        {
            var entityType = typeof(T);
            var properties = entityType.GetProperties();

            // 🔹 Gestion du tri
            if (dynamicFilters.sorts is not null && dynamicFilters.sorts.Any())
            {
                var ordered = dynamicFilters
                    .sorts.Where(x => x.Order != 0)
                    .OrderBy(x => x.Order)
                    .ToList();
                var firstSort = ordered.First();

                var property = GetProperty(firstSort.Field, properties);
                if (property != null)
                {
                    // Construire l'expression lambda dynamiquement
                    var parameter = Expression.Parameter(typeof(T), "x");
                    var propertyAccess = Expression.Property(parameter, property);
                    var lambda = Expression.Lambda(propertyAccess, parameter);

                    var orderByMethod = typeof(Queryable)
                        .GetMethods()
                        .First(m => m.Name == "OrderBy" && m.GetParameters().Length == 2)
                        .MakeGenericMethod(typeof(T), property.PropertyType);

                    var orderByDescendingMethod = typeof(Queryable)
                        .GetMethods()
                        .First(m => m.Name == "OrderByDescending" && m.GetParameters().Length == 2)
                        .MakeGenericMethod(typeof(T), property.PropertyType);

                    query =
                        firstSort.Order == 1
                            ? (IQueryable<T>)
                                orderByMethod.Invoke(null, new object[] { query, lambda })!
                            : (IQueryable<T>)
                                orderByDescendingMethod.Invoke(
                                    null,
                                    new object[] { query, lambda }
                                )!;

                    // 🔹 Tri secondaire
                    foreach (var item in ordered.Skip(1))
                    {
                        var newProperty = GetProperty(item.Field, properties);
                        if (newProperty == null)
                            continue;

                        var param2 = Expression.Parameter(typeof(T), "x");
                        var propAccess2 = Expression.Property(param2, newProperty);
                        var lambda2 = Expression.Lambda(propAccess2, param2);

                        var thenByMethod = typeof(Queryable)
                            .GetMethods()
                            .First(m => m.Name == "ThenBy" && m.GetParameters().Length == 2)
                            .MakeGenericMethod(typeof(T), newProperty.PropertyType);
                        var thenByDescendingMethod = typeof(Queryable)
                            .GetMethods()
                            .First(m =>
                                m.Name == "ThenByDescending" && m.GetParameters().Length == 2
                            )
                            .MakeGenericMethod(typeof(T), newProperty.PropertyType);

                        query =
                            item.Order == 1
                                ? (IQueryable<T>)
                                    thenByMethod.Invoke(null, new object[] { query, lambda2 })!
                                : (IQueryable<T>)
                                    thenByDescendingMethod.Invoke(
                                        null,
                                        new object[] { query, lambda2 }
                                    )!;
                    }
                }
            }
            else
            {
                // tri par défaut (première propriété)
                var property = properties.First();
                var parameter = Expression.Parameter(typeof(T), "x");
                var propertyAccess = Expression.Property(parameter, property);
                var lambda = Expression.Lambda(propertyAccess, parameter);

                var orderByMethod = typeof(Queryable)
                    .GetMethods()
                    .First(m => m.Name == "OrderBy" && m.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(T), property.PropertyType);

                var orderByDescendingMethod = typeof(Queryable)
                    .GetMethods()
                    .First(m => m.Name == "OrderByDescending" && m.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(T), property.PropertyType);

                query = (IQueryable<T>)orderByMethod.Invoke(null, new object[] { query, lambda })!;
            }

            return query;
        }

        public static IQueryable<T> ApplyDynamicWhere<T>(
            this IQueryable<T> query,
            DynamicFilters<T> dynamicFilters
        )
        {
            var entityType = typeof(T);
            var parameter = Expression.Parameter(entityType, "x");

            Expression? finalExpression = null;

            foreach (var (key, filter) in dynamicFilters.Filters)
            {
                if (filter.Value == null)
                    continue;

                // 🔹 Détecter si c'est une propriété imbriquée (contient "/")
                var propertyPath = key.Split('/');
                
                // Obtenir le membre (propriété simple ou imbriquée)
                var (member, propertyType) = GetNestedPropertyExpression(parameter, propertyPath, entityType);
                
                if (member == null || propertyType == null)
                {
                    Console.WriteLine($"Property path '{key}' not found on type {entityType.Name}");
                    continue;
                }

                Expression? expression = null;

                // Gestion spéciale pour le matchMode "any"
                if (filter.MatchMode.ToLower() == "in")
                {
                    expression = BuildAnyExpression(filter, member, propertyType, key);
                }
                else
                {
                    expression = BuildComparisonExpression(filter, member, propertyType, key);
                }

                if (expression == null)
                    continue;

                finalExpression =
                    finalExpression == null
                        ? expression
                        : Expression.AndAlso(finalExpression, expression);
            }

            if (finalExpression == null)
                return query; // aucun filtre

            var lambda = Expression.Lambda<Func<T, bool>>(finalExpression, parameter);

            return query.Where(lambda);
        }

        /// <summary>
        /// Construit une expression pour accéder à une propriété imbriquée
        /// Exemple: "Teacher/FirstName" => x.Teacher.FirstName
        /// </summary>
        private static (Expression? memberExpression, Type? propertyType) GetNestedPropertyExpression(
            Expression parameter,
            string[] propertyPath,
            Type entityType)
        {
            Expression currentExpression = parameter;
            Type currentType = entityType;

            foreach (var propertyName in propertyPath)
            {
                var property = currentType.GetProperty(
                    propertyName,
                    BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance
                );

                if (property == null)
                {
                    return (null, null);
                }

                currentExpression = Expression.Property(currentExpression, property);
                currentType = property.PropertyType;
            }

            return (currentExpression, currentType);
        }

        /// <summary>
        /// Construit une expression pour le matchMode "any" (IN clause)
        /// </summary>
        private static Expression? BuildAnyExpression(
            FilterItem filter,
            Expression member,
            Type propertyType,
            string key)
        {
            try
            {
                // Parser la valeur qui doit être un tableau JSON
                Guid[] values;

                if (filter.Value is JsonElement jsonElement)
                {
                    values = jsonElement.Deserialize<Guid[]>() ?? Array.Empty<Guid>();
                }
                else if (filter.Value is string strValue)
                {
                    values = JsonSerializer.Deserialize<Guid[]>(strValue) ?? Array.Empty<Guid>();
                }
                else
                {
                    values = (Guid[])filter.Value;
                }

                if (values.Length > 0)
                {
                    // Convertir les valeurs au type de la propriété
                    var convertedValues = values
                        .Select(v => Convert.ChangeType(v, propertyType))
                        .ToList();

                    // Créer un tableau du type approprié
                    var typedArray = Array.CreateInstance(propertyType, convertedValues.Count);
                    for (int i = 0; i < convertedValues.Count; i++)
                    {
                        typedArray.SetValue(convertedValues[i], i);
                    }

                    // Créer l'expression: array.Contains(x.Property)
                    var containsMethod = typeof(Enumerable)
                        .GetMethods()
                        .First(m => m.Name == "Contains" && m.GetParameters().Length == 2)
                        .MakeGenericMethod(propertyType);

                    var arrayConstant = Expression.Constant(typedArray);
                    return Expression.Call(null, containsMethod, arrayConstant, member);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing 'in' filter for {key}: {ex.Message}");
            }

            return null;
        }

        /// <summary>
        /// Construit une expression de comparaison (equals, contains, gt, etc.)
        /// </summary>
        private static Expression? BuildComparisonExpression(
            FilterItem filter,
            Expression member,
            Type propertyType,
            string key)
        {
            try
            {
                // Convertir la valeur au type approprié
                object convertedValue;

                if (filter.Value is JsonElement jsonElement)
                {
                    // Extraire la valeur du JsonElement selon le type de la propriété
                    convertedValue = GetValueFromJsonElement(jsonElement, propertyType);
                }
                else
                {
                    // Conversion directe si ce n'est pas un JsonElement
                    convertedValue = Convert.ChangeType(filter.Value, propertyType);
                }

                var constant = Expression.Constant(convertedValue, propertyType);

                return filter.MatchMode.ToLower() switch
                {
                    // Pour les strings, on applique ToLower() pour une comparaison insensible à la casse
                    "equals" when propertyType == typeof(string) =>
                        Expression.Equal(
                            Expression.Call(member, typeof(string).GetMethod("ToLower", Type.EmptyTypes)!),
                            Expression.Call(constant, typeof(string).GetMethod("ToLower", Type.EmptyTypes)!)
                        ),
                    
                    "equals" => Expression.Equal(member, constant),
                    
                    "notequals" when propertyType == typeof(string) =>
                        Expression.NotEqual(
                            Expression.Call(member, typeof(string).GetMethod("ToLower", Type.EmptyTypes)!),
                            Expression.Call(constant, typeof(string).GetMethod("ToLower", Type.EmptyTypes)!)
                        ),
                    
                    "notequals" => Expression.NotEqual(member, constant),

                    "contains" when propertyType == typeof(string) =>
                        Expression.Call(
                            Expression.Call(member, typeof(string).GetMethod("ToLower", Type.EmptyTypes)!),
                            nameof(string.Contains),
                            Type.EmptyTypes,
                            Expression.Call(constant, typeof(string).GetMethod("ToLower", Type.EmptyTypes)!)
                        ),

                    "startswith" when propertyType == typeof(string) =>
                        Expression.Call(
                            Expression.Call(member, typeof(string).GetMethod("ToLower", Type.EmptyTypes)!),
                            nameof(string.StartsWith),
                            Type.EmptyTypes,
                            Expression.Call(constant, typeof(string).GetMethod("ToLower", Type.EmptyTypes)!)
                        ),

                    "endswith" when propertyType == typeof(string) =>
                        Expression.Call(
                            Expression.Call(member, typeof(string).GetMethod("ToLower", Type.EmptyTypes)!),
                            nameof(string.EndsWith),
                            Type.EmptyTypes,
                            Expression.Call(constant, typeof(string).GetMethod("ToLower", Type.EmptyTypes)!)
                        ),

                    "gte" => Expression.GreaterThanOrEqual(member, constant),
                    "lte" => Expression.LessThanOrEqual(member, constant),
                    "gt" => Expression.GreaterThan(member, constant),
                    "lt" => Expression.LessThan(member, constant),

                    _ => null,
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error converting filter value for {key}: {ex.Message}");
            }

            return null;
        }

        /// <summary>
        /// Extrait la valeur d'un JsonElement et la convertit au type approprié
        /// </summary>
        private static object GetValueFromJsonElement(JsonElement element, Type targetType)
        {
            // Gérer les types nullable
            var underlyingType = Nullable.GetUnderlyingType(targetType) ?? targetType;

            return underlyingType switch
            {
                Type t when t == typeof(string) => element.GetString() ?? string.Empty,
                Type t when t == typeof(int) => element.GetInt32(),
                Type t when t == typeof(long) => element.GetInt64(),
                Type t when t == typeof(short) => element.GetInt16(),
                Type t when t == typeof(byte) => element.GetByte(),
                Type t when t == typeof(bool) => element.GetBoolean(),
                Type t when t == typeof(decimal) => element.GetDecimal(),
                Type t when t == typeof(double) => element.GetDouble(),
                Type t when t == typeof(float) => element.GetSingle(),
                Type t when t == typeof(Guid) => element.GetGuid(),
                Type t when t == typeof(DateTime) => element.GetDateTime(),
                Type t when t == typeof(DateTimeOffset) => element.GetDateTimeOffset(),
                _ => element.Deserialize(targetType) ?? throw new InvalidOperationException($"Cannot convert JsonElement to {targetType.Name}")
            };
        }

        public static IQueryable<T> ApplyPagination<T>(
            this IQueryable<T> query,
            DynamicFilters<T> dynamicFilters
        )
        {
            // 🔹 Pagination
            if (dynamicFilters.First >= 0)
                query = query.Skip(dynamicFilters.First);

            query = query.Take(dynamicFilters.Rows > 0 ? dynamicFilters.Rows : 10);
            return query;
        }

        public static async Task<(List<T> Values, long Count)> ApplyAndCountAsync<T>(
            this IQueryable<T> query,
            DynamicFilters<T> dynamicFilters
        )
        {
            query = query.ApplyDynamicWhere(dynamicFilters);
            var toto = query.ToQueryString();
            query = query.ApplySorts(dynamicFilters);
            toto = query.ToQueryString();

            var count = await query.CountAsync();

            query = query.ApplyPagination(dynamicFilters);
            toto = query.ToQueryString();

            var values = await query.ToListAsync();
            return (values, count);
        }

        public static PropertyInfo? GetProperty(string propName, PropertyInfo[] properties)
        {
            return properties.FirstOrDefault(x => x.Name.ToLower() == propName.ToLower());
        }
    }
}
