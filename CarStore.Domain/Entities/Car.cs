using CarStore.Domain.Base;

namespace CarStore.Domain.Entities
{
    public class Car : BaseEntity<int>
    {
        public string Maker { get; set; } 
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }       
        public int DealerId { get; set; }
        public Dealer Dealer { get; set; }      
    }
}
