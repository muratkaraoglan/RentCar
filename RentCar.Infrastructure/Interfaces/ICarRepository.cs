using RentCar.Domain.Entities;

namespace RentCar.Infrastructure.Interfaces;

public interface ICarRepository : IRepository<Car>
{
    Task<IEnumerable<Car>> GetAvailableCarsAsync();
}