namespace Rentaly.Application.DTOs.Cars;
public class CreateCarDto
{
    public float Kilometars { get; set; }
    public string? ImagePath { get; set; }
    public DateOnly ManufacturerYear { get; set; }
    public int ModelId { get; set; }
    public int TypeId { get; set; }
    public decimal PricePerDay { get; set; }
    public ICollection<CreateCarSpecificationDto> CarSpecifications { get; set; } = new List<CreateCarSpecificationDto>();
}

public class CreateCarSpecificationDto
{
    public int SpecificationId { get; set; }

    public string Value { get; set; }
}
