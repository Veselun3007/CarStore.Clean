using CarStore.Application.DTO.Dealer;
using CarStore.Application.Interfaces;
using CarStore.WebApi.Controllers.Base;

namespace CarStore.WebApi.Controllers
{
    public class DealerController : CrudController<DealerDTO, DealerOutDTO, int>
    {
        public DealerController(IService<DealerDTO, DealerOutDTO, int> service) : base(service) { }
    }
}
