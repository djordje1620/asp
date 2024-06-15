namespace Rentaly.Domain.Entities;
public class CarSpecification
{
    public int CarId { get; set; }
    public int SpecificationId { get; set; }
    public string Value { get; set; }
    public Car Car { get; set; }
    public Specification Specification { get; set; }
}
