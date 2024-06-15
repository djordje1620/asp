using Rentaly.Application.DTOs.Cars;

namespace Rentaly.API.DTOs;

public class CreateCarWithImageDto : CreateCarDto
{
    public IFormFile Image { get; set; }
}
