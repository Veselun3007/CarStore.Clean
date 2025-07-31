using CarStore.Clean.Application.DTO.Car;
using CarStore.Clean.Application.DTO.Dealer;
using CarStore.Clean.Application.DTO.Sale;
using CarStore.Clean.Application.DTO.User;
using CarStore.Clean.Application.Interfaces;
using CarStore.Clean.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarStore.Clean.Application
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
