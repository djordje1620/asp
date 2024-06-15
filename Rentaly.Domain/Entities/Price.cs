namespace Rentaly.Domain.Entities;
public class Price : Entity
{
    public decimal PricePerDay { get; set; }
    public int CarId { get; set; }
    public Car Car { get; set; }
}
