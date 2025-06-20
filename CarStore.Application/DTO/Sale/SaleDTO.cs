namespace CarStore.Application.DTO.Sale
{
    public class SaleDTO
    {
        public DateTime SaleDate { get; set; } = DateTime.UtcNow;
        public decimal FinalPrice { get; set; }
        public int CarId { get; set; }
        public string UserId { get; set; }
    }
}
