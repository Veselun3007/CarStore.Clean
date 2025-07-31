using CarStore.Clean.Application.DTO.Car;
using CarStore.Clean.Domain.Entities;

namespace CarStore.Clean.Application.Mappings
{
    internal class CarMapping
    {
        internal static CarOutDTO FromCar(Car car)
        {
            return new CarOutDTO
            {
                Id = car.Id,
                Maker = car.Maker,
                Model = car.Model,
                Year = car.Year,
                Price = car.Price,
                DealerId = car.DealerId,
            };
        }

        internal static Car ToCar(CarDTO car)
        {
            return new Car
            {
                Maker = car.Maker,
                Model = car.Model,
                Year = car.Year,
                Price = car.Price,
                DealerId = car.DealerId,
            };
        }
    }
}
