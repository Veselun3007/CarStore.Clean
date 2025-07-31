using CarStore.Clean.Application.DTO.Sale;
using CarStore.Clean.Application.Interfaces;
using CarStore.Clean.WebApi.Controllers.Base;

namespace CarStore.Clean.WebApi.Controllers
{
    public class SaleController : CrudController<SaleDTO, SaleOutDTO, int>
    {
        public SaleController(IService<SaleDTO, SaleOutDTO, int> service) : base(service) { }
    }
}
