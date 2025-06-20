using CarStore.Application.DTO.Sale;
using CarStore.Application.Interfaces;
using CarStore.Application.Mappings;

namespace CarStore.Application.Services
{
    internal class SaleService : IService<SaleDTO, SaleOutDTO, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public SaleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SaleOutDTO> CreateAsync(SaleDTO entity)
        {
            var addSale = await _unitOfWork.SaleRepository.AddAsync(SaleMapping.ToSale(entity));
            await _unitOfWork.CommitAsync();
            return SaleMapping.FromSale(addSale);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.SaleRepository.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<SaleOutDTO>>? GetAllAsync()
        {
            var sales = await _unitOfWork.SaleRepository.FindAllByAsync();
            return sales.Select(SaleMapping.FromSale).ToList();
        }

        public async Task<SaleOutDTO>? GetByIdAsync(int id)
        {
            var sale = await _unitOfWork.SaleRepository.GetByIdAsync(id);
            return SaleMapping.FromSale(sale);
        }

        public async Task<SaleOutDTO> UpdateAsync(int id, SaleDTO entity)
        {
            var updatedSale = await _unitOfWork.SaleRepository.UpdateAsync(id, SaleMapping.ToSale(entity));
            await _unitOfWork.CommitAsync();
            return SaleMapping.FromSale(updatedSale);
        }
    }
}
