using CarStore.Domain.Entities;

namespace CarStore.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<User, string> UserRepository { get; }
        IRepository<Car, int> CarRepository { get; }
        IRepository<Sale, int> SaleRepository { get; }
        IRepository<Dealer, int> DealerRepository { get; }

        Task<int> CommitAsync();
    }
}
