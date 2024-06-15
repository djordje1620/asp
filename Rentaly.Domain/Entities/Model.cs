namespace Rentaly.Domain.Entities;
public class Model : Entity
{
    public string Name { get; set; }
    public int BrandId { get; set; }
    public Brand Brand { get; set; }

    public ICollection<Car> Cars { get; set; } = new List<Car>();
}
