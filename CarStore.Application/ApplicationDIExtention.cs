using CarStore.Application.DTO.Car;
using CarStore.Application.DTO.Dealer;
using CarStore.Application.DTO.Sale;
using CarStore.Application.DTO.User;
using CarStore.Application.Interfaces;
using CarStore.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarStore.Application
{
    public static class ApplicationDIExtention
    {
        public static void AddApplicationServices(this IHostApplicationBuilder builder)
        {
            builder.Services.AddScoped<IService<UserDTO, UserOutDTO, string>, UserService>();
            builder.Services.AddScoped<IService<DealerDTO, DealerOutDTO, int>, DealerService>();
            builder.Services.AddScoped<IService<CarDTO, CarOutDTO, int>, CarService>();
            builder.Services.AddScoped<IService<SaleDTO, SaleOutDTO, int>, SaleService>();
        }
    }
}
