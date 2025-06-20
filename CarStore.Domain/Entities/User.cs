using CarStore.Domain.Base;

namespace CarStore.Domain.Entities
{
    public class User : BaseEntity<string>
    {
        public string UserName { get; set; }
        public string Email { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}
