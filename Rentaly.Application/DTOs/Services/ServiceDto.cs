namespace Rentaly.Application.DTOs.Services;
public class ServiceDto
{
    public int Id { get; set; }
    public string ServiceName { get; set; }
    public string Description { get; set; }
    public string Car { get; set; }
    public DateOnly FromDate { get; set; }
    public DateOnly ToDate { get; set; }
    public string ServiceType { get; set; }
}
