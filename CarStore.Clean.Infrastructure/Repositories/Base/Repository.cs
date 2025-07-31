using CarStore.Clean.Application.Interfaces;
using CarStore.Clean.Domain.Base;
using CarStore.Clean.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarStore.Clean.Infrastructure.Repositories.Base
{
    internal abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        protected readonly CarShopDBContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(CarShopDBContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public virtual async Task DeleteAsync(TKey id)
        {
            var entity = await _dbSet.FindAsync(id);
            if(entity is not null)
            {
                _dbSet.Remove(entity);
            }
        }

        public virtual async Task<IEnumerable<TEntity>?> FindAllByAsync(Expression<Func<TEntity, bool>>? filter = null)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();

            if(filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }

        public virtual async Task<TEntity?> GetByIdAsync(TKey id, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbSet.AsQueryable();
            if(includes is not null)
            {
                foreach(var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public virtual async Task<TEntity?> UpdateAsync(TKey id, TEntity entity)
        {
            var existingEntity = await _dbSet.FindAsync(id);
            entity.Id = id;
            if(existingEntity is not null)
            {
                _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
            }
            return existingEntity;
        }
    }
}
