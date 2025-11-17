using Microsoft.EntityFrameworkCore;
using RentCar.Domain.Entities;
using RentCar.Infrastructure.Data;
using RentCar.Infrastructure.Interfaces;

namespace RentCar.Infrastructure.Repositories;

public class CarRepository : Repository<Car>, ICarRepository
{
    private readonly ApplicationDbContext _db;

    public CarRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Car>> GetAvailableCarsAsync()
    {
        return await _db.Cars.Where(c => !c.IsRented).ToListAsync();
    }
}