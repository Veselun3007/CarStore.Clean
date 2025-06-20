using CarStore.Application;
using CarStore.Clean.WebApi.Swagger;
using CarStore.Infrastructure;
using CarStore.Infrastructure.Context;
using CarStore.WebApi.Middlewares;
using Microsoft.EntityFrameworkCore;

namespace CarStore.WebApi
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
            builder.Services.AddSwaggerGen( options => 
            {
                options.OperationFilter<CarTestOperationFilter>();
                options.OperationFilter<DealerTestOperationFilter>();
                options.OperationFilter<SaleTestOperationFilter>();
                options.OperationFilter<UserTestOperationFilter>();
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            using(var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<CarShopDBContext>();
                dbContext.Database.Migrate();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();
            app.Run();
        }
    }
}
