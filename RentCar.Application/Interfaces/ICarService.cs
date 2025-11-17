using RentCar.Application.DTOs;

namespace RentCar.Application.Interfaces;

public interface ICarService
{
    Task<IEnumerable<CarDto>> GetAllAsync();
    Task<CarDto?> GetByIdAsync(Guid carId);
    Task AddAsync(CarDto car);
    Task UpdateAsync(CarDto car);
    Task DeleteAsync(Guid carId);
    Task<IEnumerable<CarDto>> GetAvailableCarsAsync();
}