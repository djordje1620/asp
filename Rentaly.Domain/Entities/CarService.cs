namespace Rentaly.Domain.Entities;
public class CarService : Entity
{
    public string ServiceName { get; set; }
    public string Description { get; set; }
    public int CarId { get; set; }
    public DateOnly FromDate {  get; set; }
    public DateOnly ToDate { get; set;}
    public ServiceType ServiceType { get; set; }
    public Car Car { get; set; }
}
