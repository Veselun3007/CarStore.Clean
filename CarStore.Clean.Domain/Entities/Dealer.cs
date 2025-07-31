using CarStore.Clean.Domain.Base;

namespace CarStore.Clean.Domain.Entities
{
    public class Dealer : BaseEntity<int>
    {
        public string Name { get; set; }
        public string ContactEmail { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
