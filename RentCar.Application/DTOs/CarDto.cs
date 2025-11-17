using System.ComponentModel.DataAnnotations;

namespace RentCar.Application.DTOs;

public class CarDto
{
    public Guid Id { get; set; }
    
    [Required] [MaxLength(100)] public string Model { get; set; } = string.Empty;
    public decimal DailyPrice { get; set; }
    public bool IsRented { get; set; }
}