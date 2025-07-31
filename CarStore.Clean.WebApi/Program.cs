using CarStore.Clean.Application;
using CarStore.Clean.Infrastructure;
using CarStore.Clean.WebApi.Middlewares;
using CarStore.Clean.WebApi.Swagger;

namespace CarStore.Clean.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.AddInfrastructureServices();
            builder.AddApplicationServices();
            builder.Services.AddControllers();
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.OperationFilter<GenericTestOperationFilter>();
            });

            var app = builder.Build();

            if(app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseExceptionHandler(o => { });
            app.UseHttpsRedirection();

            app.MapControllers();
            app.Run();
        }
    }
}
