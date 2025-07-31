using CarStore.Clean.Application.DTO.Car;
using CarStore.Clean.Application.DTO.Dealer;
using CarStore.Clean.Application.DTO.Sale;
using CarStore.Clean.Application.DTO.User;

namespace CarStore.Clean.WebApi.Swagger
{
    public class TestDataFactory
    {
        public static CarDTO CarCreate()
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

        public static CarDTO CarUpdate()
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

        public static DealerDTO DealerCreate()
        {
            return new DealerDTO
            {
                Name = "Best Cars Dealer",
                ContactEmail = "contact@bestcars.com"
            };
        }

        public static DealerDTO DealerUpdate()
        {
            return new DealerDTO
            {
                Name = "Funny Cars Dealer",
                ContactEmail = "contact@bestcars.com"
            };
        }

        public static SaleDTO SaleCreate()
        {
            return new SaleDTO
            {
                SaleDate = DateTime.UtcNow,
                FinalPrice = 34000m,
                CarId = 1,
                UserId = "00000000-0000-0000-0000-000000000001"
            };
        }

        public static SaleDTO SaleUpdate()
        {
            return new SaleDTO
            {
                SaleDate = DateTime.UtcNow,
                FinalPrice = 38000m,
                CarId = 1,
                UserId = "00000000-0000-0000-0000-000000000001"
            };
        }

        public static UserDTO UserCreate()
        {
            return new UserDTO
            {
                UserName = "john_doe",
                Email = "john.doe@example.com"
            };
        }
    }
}
