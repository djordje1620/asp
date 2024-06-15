namespace Rentaly.Domain.Entities;
public class Role : Entity
{
    public string Name { get; set; }
    public IEnumerable<User> Users { get; set; } = new List<User>();
    public ICollection<RoleUseCases> RoleUseCases { get; set; }
}
