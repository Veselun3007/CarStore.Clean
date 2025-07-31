using CarStore.Clean.Application.DTO.Dealer;
using CarStore.Clean.Application.Interfaces;
using CarStore.Clean.WebApi.Controllers.Base;

namespace CarStore.Clean.WebApi.Controllers
{
    public class DealerController : CrudController<DealerDTO, DealerOutDTO, int>
    {
        public DealerController(IService<DealerDTO, DealerOutDTO, int> service) : base(service) { }
    }
}
