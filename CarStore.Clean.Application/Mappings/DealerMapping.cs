using CarStore.Clean.Application.DTO.Dealer;
using CarStore.Clean.Domain.Entities;

namespace CarStore.Clean.Application.Mappings
{
    internal class DealerMapping
    {
        internal static DealerOutDTO FromDealer(Dealer dealer)
        {
            return new DealerOutDTO
            {
                Id = dealer.Id,
                Name = dealer.Name,
                ContactEmail = dealer.ContactEmail,
            };
        }

        internal static Dealer ToDealer(DealerDTO dealer)
        {
            return new Dealer
            {
                Name = dealer.Name,
                ContactEmail = dealer.ContactEmail,
            };
        }
    }
}
