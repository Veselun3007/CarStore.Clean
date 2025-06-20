using CarStore.Application.DTO.Sale;
using CarStore.Application.Interfaces;
using CarStore.WebApi.Controllers.Base;

namespace CarStore.WebApi.Controllers
{
    public class SaleController : CrudController<SaleDTO, SaleOutDTO, int>
    {
        public SaleController(IService<SaleDTO, SaleOutDTO, int> service) : base(service) { }
    }
}
