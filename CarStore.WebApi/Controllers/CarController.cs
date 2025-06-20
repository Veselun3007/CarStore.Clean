using CarStore.Application.DTO.Car;
using CarStore.Application.Interfaces;
using CarStore.WebApi.Controllers.Base;

namespace CarStore.WebApi.Controllers
{
    public class CarController : CrudController<CarDTO, CarOutDTO, int>
    {
        public CarController(IService<CarDTO, CarOutDTO, int> service) : base(service) { }
    }
}
