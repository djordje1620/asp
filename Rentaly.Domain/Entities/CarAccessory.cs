namespace Rentaly.Domain.Entities;
public class CarAccessory : Entity
{
    public string Name { get; set; }
    public ICollection<BookingCarAccessories> Bookings { get; set; } = new List<BookingCarAccessories>();
}
