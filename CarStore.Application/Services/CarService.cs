using CarStore.Application.DTO.Car;
using CarStore.Application.Interfaces;
using CarStore.Application.Mappings;

namespace CarStore.Application.Services
{
    internal class CarService : IService<CarDTO, CarOutDTO, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CarService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CarOutDTO> CreateAsync(CarDTO entity)
        {
            var addCar = await _unitOfWork.CarRepository.AddAsync(CarMapping.ToCar(entity));
            await _unitOfWork.CommitAsync();
            return CarMapping.FromCar(addCar);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.CarRepository.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<CarOutDTO>>? GetAllAsync()
        {
            var cars = await _unitOfWork.CarRepository.FindAllByAsync();
            return cars.Select(CarMapping.FromCar).ToList();
        }

        public async Task<CarOutDTO>? GetByIdAsync(int id)
        {
            var car = await _unitOfWork.CarRepository.GetByIdAsync(id);
            return CarMapping.FromCar(car);
        }

        public async Task<CarOutDTO> UpdateAsync(int id, CarDTO entity)
        {
            var updatedCar = await _unitOfWork.CarRepository.UpdateAsync(id, CarMapping.ToCar(entity));
            await _unitOfWork.CommitAsync();
            return CarMapping.FromCar(updatedCar);
        }
    }
}
