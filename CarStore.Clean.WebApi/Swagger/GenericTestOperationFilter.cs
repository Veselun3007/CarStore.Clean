using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Net.Mime;
using System.Reflection;
using System.Text.Json;

namespace CarStore.Clean.WebApi.Swagger
{
    public class GenericTestOperationFilter : IOperationFilter
    {
        private readonly JsonSerializerOptions _jsonOptions = new()
        {
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var controllerName = context.MethodInfo.DeclaringType?.Name?.Replace("Controller", "");
            var methodName = context.MethodInfo.Name;

            var factoryType = typeof(TestDataFactory);
            var method = factoryType.GetMethod($"{controllerName}{methodName}", BindingFlags.Public | BindingFlags.Static);
            if(method is null)
            {
                return;
            }

            var sampleObject = method.Invoke(null, null);
            if(sampleObject is null)
            {
                return;
            }

            var example = new Dictionary<string, IOpenApiAny>
            {
                [$"{methodName} {controllerName?.ToLower()}"] = ToOpenApiValue(sampleObject)
            };

            ApplyExamples(operation.RequestBody, example);
        }

        private static void ApplyExamples(OpenApiRequestBody requestBody, Dictionary<string, IOpenApiAny> examples)
        {
            if(!requestBody.Content.TryGetValue(MediaTypeNames.Application.Json, out var content))
            {
                return;
            }

            foreach(var example in examples)
            {
                content.Examples.Add(example.Key, new OpenApiExample
                {
                    Summary = example.Key,
                    Value = example.Value,
                });
            }
        }

        private IOpenApiAny ToOpenApiValue<T>(T value) =>
            OpenApiAnyFactory.CreateFromJson(JsonSerializer.Serialize(value, _jsonOptions));
    }
}
