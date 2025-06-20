using CarStore.Application.DTO.Car;
using CarStore.Application.DTO.Dealer;
using CarStore.Application.DTO.Sale;
using CarStore.Application.DTO.User;

namespace CarStore.Clean.WebApi.Swagger
{
    public class TestDataFactory
    {
        public static CarDTO CreateCar()
        {
            return new CarDTO
            {
                Maker = "Toyota",
                Model = "Camry",
                Year = 2023,
                Price = 35000m,
                DealerId = 1
            };
        }

        public static CarDTO UpdateCar()
        {
            return new CarDTO
            {
                Maker = "Toyota",
                Model = "Camry",
                Year = 2024,
                Price = 40000m,
                DealerId = 1
            };
        }

        public static DealerDTO CreateDealer()
        {
            return new DealerDTO
            {
                Name = "Best Cars Dealer",
                ContactEmail = "contact@bestcars.com"
            };
        }

        public static DealerDTO UpdateDealer()
        {
            return new DealerDTO
            {
                Name = "Funny Cars Dealer",
                ContactEmail = "contact@bestcars.com"
            };
        }

        public static SaleDTO CreateSale()
        {
            return new SaleDTO
            {
                SaleDate = DateTime.UtcNow,
                FinalPrice = 34000m,
                CarId = 1,
                UserId = "set from get allUser"
            };
        }

        public static SaleDTO UpdateSale()
        {
            return new SaleDTO
            {
                SaleDate = DateTime.UtcNow,
                FinalPrice = 38000m,
                CarId = 1,
                UserId = "set from get allUser"
            };
        }

        public static UserDTO CreateUser()
        {
            return new UserDTO
            {
                UserName = "john_doe",
                Email = "john.doe@example.com"
            };
        }
    }
}
