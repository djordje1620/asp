namespace Rentaly.Application.DTOs.Bookings;
public class UpdateBookingDto
{
    public int Id { get; set; }
    public DateOnly FromDate {  get; set; }
    public DateOnly ToDate { get; set; }

}
