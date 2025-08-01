﻿using CarStore.Clean.Application.Interfaces;
using CarStore.Clean.Domain.Entities;
using CarStore.Clean.Infrastructure.Context;

namespace CarStore.Clean.Infrastructure.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly CarShopDBContext _context;

        public UnitOfWork(CarShopDBContext context)
        {
            _context = context;

            UserRepository = new UserRepository(_context);
            CarRepository = new CarRepository(_context);
            SaleRepository = new SaleRepository(_context);
            DealerRepository = new DealerRepository(_context);
        }

        public IRepository<User, string> UserRepository { get; private set; }

        public IRepository<Car, int> CarRepository { get; private set; }

        public IRepository<Sale, int> SaleRepository { get; private set; }

        public IRepository<Dealer, int> DealerRepository { get; private set; }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
