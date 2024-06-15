namespace Rentaly.Domain.Entities;
public class BookingCarAccessories
{
    public int BookingId { get; set; }
    public int CarAccessoryId { get; set; }
    public Booking Booking { get; set; }
    public CarAccessory CarAccessory { get; set; }

}
