using CarStore.Domain.Base;

namespace CarStore.Domain.Entities
{
    public class Sale : BaseEntity<int>
    {
        public DateTime SaleDate { get; set; }
        public decimal FinalPrice { get; set; }
        
        public int CarId { get; set; }
        public Car Car { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }        
    }
}
