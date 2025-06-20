using CarStore.Application.DTO.Dealer;
using CarStore.Application.Interfaces;
using CarStore.Application.Mappings;

namespace CarStore.Application.Services
{
    internal class DealerService : IService<DealerDTO, DealerOutDTO, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DealerService(IUnitOfWork unitOfWork) 
        { 
            _unitOfWork = unitOfWork;
        }

        public async Task<DealerOutDTO> CreateAsync(DealerDTO entity)
        {
            var addDealer = await _unitOfWork.DealerRepository.AddAsync(DealerMapping.ToDealer(entity));
            await _unitOfWork.CommitAsync();
            return DealerMapping.FromDealer(addDealer);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.DealerRepository.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<DealerOutDTO>>? GetAllAsync()
        {
            var dealers = await _unitOfWork.DealerRepository.FindAllByAsync();
            return dealers.Select(DealerMapping.FromDealer).ToList();
        }

        public async Task<DealerOutDTO>? GetByIdAsync(int id)
        {
            var dealer = await _unitOfWork.DealerRepository.GetByIdAsync(id);
            return DealerMapping.FromDealer(dealer);
        }

        public async Task<DealerOutDTO> UpdateAsync(int id, DealerDTO entity)
        {
            var updatedDealer = await _unitOfWork.DealerRepository.UpdateAsync(id, DealerMapping.ToDealer(entity));
            await _unitOfWork.CommitAsync();
            return DealerMapping.FromDealer(updatedDealer);
        }
    }
}
