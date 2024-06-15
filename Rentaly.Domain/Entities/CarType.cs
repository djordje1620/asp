namespace Rentaly.Domain.Entities
{
    public class CarType : Entity
    {
        public string Name { get; set; }
        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
