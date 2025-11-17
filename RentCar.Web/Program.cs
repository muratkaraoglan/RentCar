using Microsoft.EntityFrameworkCore;
using RentCar.Application.Interfaces;
using RentCar.Application.Services;
using RentCar.Infrastructure.Data;
using RentCar.Infrastructure.Interfaces;
using RentCar.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICarService, CarService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapGet("/", async (ICarService carService) => Results.Ok(await carService.GetAllAsync()));
app.MapGet("/{id:guid}", async (Guid id, ICarService carService) =>
{
    var carDto = await carService.GetByIdAsync(id);
    return carDto is not null ? Results.Ok(carDto) : Results.NotFound();
});
app.Run();