using CarStore.Application.DTO.User;
using CarStore.Application.Interfaces;
using CarStore.WebApi.Controllers.Base;

namespace CarStore.WebApi.Controllers
{
    public class UserController : CrudController<UserDTO, UserOutDTO, string>
    {
        public UserController(IService<UserDTO, UserOutDTO, string> service) : base(service) { }
    }
}
