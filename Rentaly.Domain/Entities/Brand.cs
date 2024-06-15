namespace Rentaly.Domain.Entities;
public class Brand : Entity
{
    public string Name { get; set; }
    public ICollection<Model> Models { get; set; } = new List<Model>();
}
