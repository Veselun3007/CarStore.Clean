using CarStore.Application.Interfaces;
using CarStore.Clean.Infrastructure.Options;
using CarStore.Infrastructure.Context;
using CarStore.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarStore.Infrastructure
{
    public static class InfrastructureDIExtention
    {
        public static void AddInfrastructureServices(this IHostApplicationBuilder builder)
        {
            var dbOptions = builder.Configuration.GetSection(nameof(DbOptions)).Get<DbOptions>() ?? new DbOptions();
            builder.Services.AddDbContext<CarShopDBContext>((options) =>
            {
                options.UseNpgsql(dbOptions.ConnectionString);
            });

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
