using CarStore.Clean.Domain.Base;

namespace CarStore.Clean.Domain.Entities
{
    public class User : BaseEntity<string>
    {
        public string UserName { get; set; }
        public string Email { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}
