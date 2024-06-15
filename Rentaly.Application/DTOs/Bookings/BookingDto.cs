using Rentaly.Application.DTOs.Cars;

namespace Rentaly.Application.DTOs.Bookings;
public class BookingDto
{
    public int Id { get; set; }
    public DateOnly? FromDate { get; set; }
    public DateOnly? ToDate { get; set; }
    public decimal TotalPrice { get; set; }
    public string Status { get; set; }
    public CarInfoDto Car { get; set; }
    public UserInfoDto User {  get; set; }
}

public class UserInfoDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string UserEmail { get; set; }
}

public class CarInfoDto
{
    public int Id { get; set; }
    public DateOnly ManufacturerYear { get; set; }
    public float Kilometars {  get; set; }
    public string Name { get; set; }
}
