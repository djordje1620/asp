using Newtonsoft.Json;
using Rentaly.Domain.Entities;

namespace Rentaly.Application.DTOs.Services;
public class CreateServiceDto
{
    public string ServiceName { get; set; }
    public string Description { get; set; }
    public int CarId { get; set; }
    public DateOnly FromDate { get; set; }
    public DateOnly ToDate { get; set; }
    public ServiceType ServiceType { get; set; }
}
