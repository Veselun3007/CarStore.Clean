using CarStore.Clean.Application.DTO.Car;
using CarStore.Clean.Application.Interfaces;
using CarStore.Clean.WebApi.Controllers.Base;

namespace CarStore.Clean.WebApi.Controllers
{
    public class CarController : CrudController<CarDTO, CarOutDTO, int>
    {
        public CarController(IService<CarDTO, CarOutDTO, int> service) : base(service) { }
    }
}
