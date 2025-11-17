using System.ComponentModel.DataAnnotations;

namespace RentCar.Domain.Entities;

public class Car
{
    [Key] public Guid Id { get; set; }
    [Required] [MaxLength(100)] public string Model { get; set; } = string.Empty;
    public decimal DailyPrice { get; set; }
    public bool IsRented { get; set; }

    public void Rent()
    {
        if (IsRented) throw new InvalidOperationException("Car is already rented");
        IsRented = true;
    }

    public void Return() => IsRented = false;
}