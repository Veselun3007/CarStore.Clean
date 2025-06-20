using CarStore.Domain.Base;

namespace CarStore.Domain.Entities
{
    public class Dealer : BaseEntity<int>
    {
        public string Name { get; set; }
        public string ContactEmail { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
