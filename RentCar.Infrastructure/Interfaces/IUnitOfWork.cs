namespace RentCar.Infrastructure.Interfaces;

public interface IUnitOfWork : IDisposable
{
    ICarRepository Cars { get; }
    Task<int> SaveChangesAsync();
}