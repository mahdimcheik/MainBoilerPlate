using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MainBoilerPlate.Utilities;
public class ODataQueryOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        // On cherche les actions avec un paramètre ODataQueryOptions
        if (context.MethodInfo.GetParameters().Any(p =>
            p.ParameterType.Name.StartsWith("ODataQueryOptions")))
        {
            // On retire le gros paramètre inutile
            operation.Parameters.Clear();

            // On ajoute des query params explicites
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "$filter",
                In = ParameterLocation.Query,
                Description = "Filtrer les résultats. Exemple: Country eq 'France'",
                Schema = new OpenApiSchema { Type = "string" }
            });

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "$orderby",
                In = ParameterLocation.Query,
                Description = "Trier les résultats. Exemple: City asc",
                Schema = new OpenApiSchema { Type = "string" }
            });

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "$top",
                In = ParameterLocation.Query,
                Description = "Nombre maximum d’éléments à retourner.",
                Schema = new OpenApiSchema { Type = "integer", Format = "int32" }
            });

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "$skip",
                In = ParameterLocation.Query,
                Description = "Nombre d’éléments à ignorer.",
                Schema = new OpenApiSchema { Type = "integer", Format = "int32" }
            });

            //operation.Parameters.Add(new OpenApiParameter
            //{
            //    Name = "$select",
            //    In = ParameterLocation.Query,
            //    Description = "Champs à sélectionner. Exemple: City,Country",
            //    Schema = new OpenApiSchema { Type = "string" }
            //});
        }
    }
}
