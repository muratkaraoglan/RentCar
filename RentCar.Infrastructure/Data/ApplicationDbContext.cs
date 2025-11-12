using Microsoft.EntityFrameworkCore;
using RentCar.Domain.Entities;

namespace RentCar.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<Car> Cars { get; set; }
}