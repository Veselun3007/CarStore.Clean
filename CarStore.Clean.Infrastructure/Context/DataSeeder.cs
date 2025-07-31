using CarStore.Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarStore.Clean.Infrastructure.Context
{
    public static class DataSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            static DateTime Utc(string iso8601) =>
                DateTime.SpecifyKind(DateTime.Parse(iso8601), DateTimeKind.Utc);

            var user1Id = "00000000-0000-0000-0000-000000000001";
            var user2Id = "00000000-0000-0000-0000-000000000002";

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = user1Id,
                    UserName = "johndoe",
                    Email = "john@example.com"
                },
                new User
                {
                    Id = user2Id,
                    UserName = "janedoe",
                    Email = "jane@example.com"
                }
            );

            modelBuilder.Entity<Dealer>().HasData(
                new Dealer
                {
                    Id = 1,
                    Name = "City Auto",
                    ContactEmail = "contact@cityauto.com"
                },
                new Dealer
                {
                    Id = 2,
                    Name = "Best Motors",
                    ContactEmail = "sales@bestmotors.com"
                }
            );

            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    Id = 1,
                    Maker = "Toyota",
                    Model = "Camry",
                    Year = 2020,
                    Price = 22000,
                    DealerId = 1
                },
                new Car
                {
                    Id = 2,
                    Maker = "Ford",
                    Model = "Focus",
                    Year = 2019,
                    Price = 18000,
                    DealerId = 2
                }
            );

            modelBuilder.Entity<Sale>().HasData(
                new Sale
                {
                    Id = 1,
                    CarId = 1,
                    FinalPrice = 21500,
                    SaleDate = Utc("2025-01-10T15:00:00Z"),
                    UserId = user2Id
                },
                new Sale
                {
                    Id = 2,
                    CarId = 2,
                    FinalPrice = 17500,
                    SaleDate = Utc("2025-02-20T13:30:00Z"),
                    UserId = user1Id
                }
            );
        }
    }
}
