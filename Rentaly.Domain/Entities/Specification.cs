namespace Rentaly.Domain.Entities;
public class Specification : Entity
{
    public string Name { get; set; }
    public ICollection<CarSpecification> Cars { get; set; }
}
