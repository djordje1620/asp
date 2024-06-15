using Rentaly.Application.DTOs.Cars;

namespace Rentaly.Application.DTOs.Models;
public class ModelDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Brand { get; set; }
    public ICollection<CarDetailsDto> Cars { get; set; } = new List<CarDetailsDto>();
}

public class CarDetailsDto
{
    public int Id { get; set; }
    public string Name { get; set; }

}