using CarStore.Clean.Application.DTO.User;
using CarStore.Clean.Application.Interfaces;
using CarStore.Clean.WebApi.Controllers.Base;

namespace CarStore.Clean.WebApi.Controllers
{
    public class UserController : CrudController<UserDTO, UserOutDTO, string>
    {
        public UserController(IService<UserDTO, UserOutDTO, string> service) : base(service) { }
    }
}
