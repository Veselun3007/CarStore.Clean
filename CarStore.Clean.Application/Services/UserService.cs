using CarStore.Clean.Application.DTO.User;
using CarStore.Clean.Application.Interfaces;
using CarStore.Clean.Application.Mappings;

namespace CarStore.Clean.Application.Services
{
    internal class UserService : IService<UserDTO, UserOutDTO, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserOutDTO> CreateAsync(UserDTO entity)
        {
            var addUser = await _unitOfWork.UserRepository.AddAsync(UserMapping.ToUser(entity));
            await _unitOfWork.CommitAsync();
            return UserMapping.FromUser(addUser);
        }

        public async Task DeleteAsync(string id)
        {
            await _unitOfWork.UserRepository.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<UserOutDTO>>? GetAllAsync()
        {
            var users = await _unitOfWork.UserRepository.FindAllByAsync();
            return users.Select(UserMapping.FromUser).ToList();
        }

        public async Task<UserOutDTO>? GetByIdAsync(string id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            return UserMapping.FromUser(user);
        }

        public async Task<UserOutDTO> UpdateAsync(string id, UserDTO entity)
        {
            var updatedUser = await _unitOfWork.UserRepository.UpdateAsync(id, UserMapping.ToUser(entity));
            await _unitOfWork.CommitAsync();
            return UserMapping.FromUser(updatedUser);
        }
    }
}
