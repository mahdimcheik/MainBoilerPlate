using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace MainBoilerPlate.Models
{
    public enum MatchMode
    {
        equals,
        contains,
        gt,
        lt,
        any,
        range,
    }

    public class Sort
    {
        public string Field { get; set; }
        public int Order { get; set; }
    }

    public class FilterItem
    {
        public required string? Value { get; set; }
        public required string MatchMode { get; set; }
    }

    public class DynamicFilters<T>
    {
        public int First { get; set; }
        public int Rows { get; set; }
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
                                m.Name == "thenByDescending" && m.GetParameters().Length == 2
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

            // 🔹 Pagination
            if (dynamicFilters.First >= 0)
                query = query.Skip(dynamicFilters.First);

            query = query.Take(dynamicFilters.Rows > 0 ? dynamicFilters.Rows : 10);

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
                var property = entityType.GetProperty(
                    key,
                    BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance
                );
                if (property == null || filter.Value == null)
                    continue;

                // x.PropName
                var member = Expression.Property(parameter, property);

                // valeur à comparer
                var constant = Expression.Constant(
                    Convert.ChangeType(filter.Value, property.PropertyType)
                );

                Expression? expression = filter.MatchMode.ToLower() switch
                {
                    "equals" => Expression.Equal(member, constant),
                    "notequals" => Expression.NotEqual(member, constant),

                    "contains" when property.PropertyType == typeof(string) => Expression.Call(
                        member,
                        nameof(string.Contains),
                        Type.EmptyTypes,
                        constant
                    ),

                    "startswith" when property.PropertyType == typeof(string) => Expression.Call(
                        member,
                        nameof(string.StartsWith),
                        Type.EmptyTypes,
                        constant
                    ),

                    "endswith" when property.PropertyType == typeof(string) => Expression.Call(
                        member,
                        nameof(string.EndsWith),
                        Type.EmptyTypes,
                        constant
                    ),

                    "gte" => Expression.GreaterThanOrEqual(member, constant),
                    "lte" => Expression.LessThanOrEqual(member, constant),
                    "gt" => Expression.GreaterThan(member, constant),
                    "lt" => Expression.LessThan(member, constant),

                    _ => null,
                };

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

        public static PropertyInfo? GetProperty(string propName, PropertyInfo[] properties)
        {
            return properties.FirstOrDefault(x => x.Name.ToLower() == propName.ToLower());
        }
    }
}
