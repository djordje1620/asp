namespace Rentaly.Application.DTOs.Bookings;
public class CreateBookingDto
{
    public DateOnly FromDate { get; set; }
    public DateOnly ToDate { get; set; }
    public int CarId { get; set; }
    public int UserId { get; set; }
    public List<int> CarAccessoryIds { get; set; } 
}
