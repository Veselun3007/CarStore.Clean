using CarStore.Application.DTO.User;
using CarStore.Domain.Entities;

namespace CarStore.Application.Mappings
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
