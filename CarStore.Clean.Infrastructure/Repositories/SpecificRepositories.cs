using CarStore.Clean.Domain.Entities;
using CarStore.Clean.Infrastructure.Context;
using CarStore.Clean.Infrastructure.Repositories.Base;

namespace CarStore.Clean.Infrastructure.Repositories
{
    internal class UserRepository : Repository<User, string>
    {
        internal UserRepository(CarShopDBContext dbContext) : base(dbContext) { }

        public override async Task<User> AddAsync(User entity)
        {
            entity.Id = Guid.NewGuid().ToString();
            await _dbSet.AddAsync(entity);
            return entity;
        }
    }
    internal class CarRepository : Repository<Car, int>
    {
        internal CarRepository(CarShopDBContext dbContext) : base(dbContext) { }
    }
    internal class SaleRepository : Repository<Sale, int>
    {
        internal SaleRepository(CarShopDBContext dbContext) : base(dbContext) { }
    }
    internal class DealerRepository : Repository<Dealer, int>
    {
        internal DealerRepository(CarShopDBContext dbContext) : base(dbContext) { }
    }
}
