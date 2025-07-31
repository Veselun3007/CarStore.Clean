using CarStore.Clean.Domain.Base;
using System.Linq.Expressions;

namespace CarStore.Clean.Application.Interfaces
{
    public interface IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        Task<TEntity> AddAsync(TEntity entity);

        Task DeleteAsync(TKey id);

        Task<TEntity?> UpdateAsync(TKey id, TEntity entity);

        Task<IEnumerable<TEntity>?> FindAllByAsync(Expression<Func<TEntity, bool>>? filter = null);

        Task<TEntity?> GetByIdAsync(TKey id, params Expression<Func<TEntity, object>>[] includes);
    }
}
