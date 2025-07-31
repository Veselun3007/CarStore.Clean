namespace CarStore.Clean.Application.DTO.Sale
{
    public class SaleOutDTO
    {
        public int Id { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal FinalPrice { get; set; }
        public int CarId { get; set; }
        public string UserId { get; set; }
    }
}
