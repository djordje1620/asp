namespace Rentaly.Application.DTOs.Brands;
public class BrandDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<ModelInfoDto> Models { get; set; } = new List<ModelInfoDto>();
}

public class ModelInfoDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int TotalCarCount { get; set; }

}