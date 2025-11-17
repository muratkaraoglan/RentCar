using RentCar.Application.DTOs;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;
using RentCar.Infrastructure.Interfaces;

namespace RentCar.Application.Services;

public class CarService : ICarService
{
    private readonly IUnitOfWork _unitOfWork;

    public CarService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<CarDto>> GetAllAsync()
    {
        var cars = await _unitOfWork.Cars.GetAllAsync();
        return cars.Select(c => new CarDto()
        {
            Id = c.Id,
        }).ToList();
    }

    public async Task<CarDto?> GetByIdAsync(Guid carId)
    {
        var car = await _unitOfWork.Cars.GetAsync(c => c.Id == carId);
        if (car == null) return null;
        return new CarDto()
        {
            Id = car.Id,
            DailyPrice = car.DailyPrice,
            IsRented = car.IsRented,
        };
    }

    public async Task AddAsync(CarDto carDto)
    {
        var car = new Car()
        {
            DailyPrice = carDto.DailyPrice,
            IsRented = carDto.IsRented,
            Model = carDto.Model
        };
        await _unitOfWork.Cars.AddAsync(car);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(CarDto carDto)
    {
        var car = await _unitOfWork.Cars.GetAsync(c => c.Id == carDto.Id);
        if (car == null) return;

        car.Model = carDto.Model;
        car.DailyPrice = carDto.DailyPrice;
        car.IsRented = carDto.IsRented;

        _unitOfWork.Cars.Update(car);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid carId)
    {
        var car = await _unitOfWork.Cars.GetAsync(c => c.Id == carId);
        if (car == null) return;

        _unitOfWork.Cars.Remove(car);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<CarDto>> GetAvailableCarsAsync()
    {
        var cars = await _unitOfWork.Cars.GetAvailableCarsAsync();

        return cars.Select(c => new CarDto()
        {
            Id = c.Id,
            Model = c.Model,
            DailyPrice = c.DailyPrice,
            IsRented = c.IsRented
        }).ToList();
    }
}