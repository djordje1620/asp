namespace Rentaly.Domain.Entities;
public class Review : Entity
{
    public float StarsRate { get; set; }
    public string Comment { get; set; }
    public int UserId { get; set; }
    public int CarId { get; set; }
    public Car Car { get; set; }
    public User User { get; set; }
}
