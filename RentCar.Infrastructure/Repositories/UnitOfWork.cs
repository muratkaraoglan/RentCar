using RentCar.Infrastructure.Data;
using RentCar.Infrastructure.Interfaces;

namespace RentCar.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private ApplicationDbContext _db;
    public ICarRepository Cars { get; }

    public UnitOfWork(ApplicationDbContext db)
    {
        _db = db;
        Cars = new CarRepository(_db);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _db.SaveChangesAsync();
    }

    public void Dispose()
    {
        _db.Dispose();
    }
}