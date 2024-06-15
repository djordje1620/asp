namespace Rentaly.Domain.Entities;
public class Car : Entity
{
    public float Kilometars { get; set; }
    public string ImagePath { get; set; }
    public string VIN { get; set; } = Guid.NewGuid().ToString();
    public DateOnly ManufacturerYear { get; set; }
    public int ModelId { get; set; }
    public int TypeId { get; set; }
    public Model Model { get; set; }
    public CarType Type { get; set; }
    public ICollection<CarSpecification> CarSpecifications { get; set; } = new List<CarSpecification>();
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    public ICollection<Price> Prices { get; set; } = new List<Price>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
    public ICollection<CarService> CarServices { get; set; } = new List<CarService>();
}
