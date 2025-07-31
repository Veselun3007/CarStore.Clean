namespace CarStore.Clean.Domain.Base
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
