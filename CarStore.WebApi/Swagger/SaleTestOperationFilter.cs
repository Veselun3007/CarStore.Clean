using CarStore.WebApi.Controllers;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Net.Mime;
using System.Text.Json;

namespace CarStore.Clean.WebApi.Swagger
{
    public class SaleTestOperationFilter : IOperationFilter
    {
        private readonly JsonSerializerOptions _jsonOptions = new()
        {
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            switch(context.MethodInfo.Name)
            {
                case nameof(SaleController.Create):
                    var examplesAdd = new Dictionary<string, IOpenApiAny>
                    {
                        ["Add sale"] = ToOpenApiValue(TestDataFactory.CreateCar())
                    };
                    ApplyExamples(operation.RequestBody, examplesAdd);
                    break;
                case nameof(SaleController.Update):
                    var examplesEdit = new Dictionary<string, IOpenApiAny>
                    {
                        ["Edit sale"] = ToOpenApiValue(TestDataFactory.UpdateCar())
                    };
                    ApplyExamples(operation.RequestBody, examplesEdit);
                    break;
            }
        }

        private static void ApplyExamples(OpenApiRequestBody requestBody, Dictionary<string, IOpenApiAny> examples)
        {
            if(!requestBody.Content.TryGetValue(MediaTypeNames.Application.Json, out var content))
                return;

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
