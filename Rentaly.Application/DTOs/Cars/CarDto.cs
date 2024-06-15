using Rentaly.Application.DTOs.Bookings;

namespace Rentaly.Application.DTOs.Cars;
public class CarDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Kilometars { get; set; }
    public string VIN {  get; set; }
    public string ImagePath { get; set; }
    public int ManufacturerYear { get; set; } 
    public string PricePerDay { get; set; }
    public string Type { get; set; }
    public float StarsRate { get; set; }
    public IEnumerable<ReviewDto> Reviews { get; set; }
    public IEnumerable<SpecificationDto> Specifications { get; set; }
}

public class ReviewDto
{
    public int Id { get; set; }
    public string User { get; set; }
    public float Stars { get; set; }
    public string Comment { get; set; }
}

public class SpecificationDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
}
