using CarStore.Clean.Application.DTO.Sale;
using CarStore.Clean.Domain.Entities;

namespace CarStore.Clean.Application.Mappings
{
    internal class SaleMapping
    {
        internal static SaleOutDTO FromSale(Sale sale)
        {
            return new SaleOutDTO
            {
                Id = sale.Id,
                SaleDate = sale.SaleDate,
                FinalPrice = sale.FinalPrice,
                CarId = sale.CarId,
                UserId = sale.UserId,
            };
        }

        internal static Sale ToSale(SaleDTO sale)
        {
            return new Sale
            {
                SaleDate = sale.SaleDate,
                FinalPrice = sale.FinalPrice,
                CarId = sale.CarId,
                UserId = sale.UserId,
            };
        }
    }
}
