namespace CarStore.Application.DTO.Car
{
    public class CarOutDTO
    {
        public int Id { get; set; }
        public string Maker { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public int DealerId { get; set; }
    }
}
