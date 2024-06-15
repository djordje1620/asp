namespace Rentaly.Domain.Entities;
public class Booking : Entity
{
    public DateOnly FromDate { get; set; }
    public DateOnly ToDate { get; set; }
    public decimal TotalPrice { get; set; }
    public string Status { get; set; } = BookingStatus.Upcoming.ToString();
    public int CarId { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public Car Car { get; set; }
    public ICollection<BookingCarAccessories> CarAccessories { get; set; } = new List<BookingCarAccessories>();
}
