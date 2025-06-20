using CarStore.Application.DTO.Car;
using CarStore.Domain.Entities;

namespace CarStore.Application.Mappings
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
