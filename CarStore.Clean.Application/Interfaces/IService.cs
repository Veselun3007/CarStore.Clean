namespace CarStore.Clean.Application.Interfaces
{
    public interface IService<IEntity, OEntity, TKey>
        where IEntity : class
        where OEntity : class
    {
        public Task<OEntity> CreateAsync(IEntity entity);
        public Task<OEntity> UpdateAsync(TKey id, IEntity entity);
        public Task DeleteAsync(TKey id);
        public Task<OEntity>? GetByIdAsync(TKey id);
        public Task<IEnumerable<OEntity>>? GetAllAsync();
    }
}
