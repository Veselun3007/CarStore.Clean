using CarStore.Clean.Domain.Entities;
using CarStore.Clean.Infrastructure.Context.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CarStore.Clean.Infrastructure.Context
{
    public class CarShopDBContext : DbContext
    {
        public CarShopDBContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public DbSet<Dealer> Dealers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new UserConfiguration().Configure(modelBuilder.Entity<User>());
            new CarConfiguration().Configure(modelBuilder.Entity<Car>());
            new SaleConfiguration().Configure(modelBuilder.Entity<Sale>());
            new DealerConfiguration().Configure(modelBuilder.Entity<Dealer>());

            DataSeeder.Seed(modelBuilder);
        }
    }
}
