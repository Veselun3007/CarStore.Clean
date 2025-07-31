using CarStore.Clean.Application.DTO.User;
using CarStore.Clean.Domain.Entities;

namespace CarStore.Clean.Application.Mappings
{
    internal class UserMapping
    {
        internal static UserOutDTO FromUser(User user)
        {
            return new UserOutDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
            };
        }

        internal static User ToUser(UserDTO user)
        {
            return new User
            {
                UserName = user.UserName,
                Email = user.Email,
            };
        }
    }
}
