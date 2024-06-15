using AutoMapper;
using Rentaly.Application.DTOs.Brands;
using Rentaly.Domain.Entities;

namespace Rentaly.Implementation.Mappings;
public class BrandProfile : Profile
{
    public BrandProfile()
    {
        CreateMap<Brand, BrandDto>()
            .ForMember(dest => dest.Models, opt => opt.MapFrom(src => src.Models.Select(x => new ModelInfoDto
                {
                    Id = x.Id,
                    TotalCarCount = x.Cars.Count(),
                    Name = x.Name,
                })
                .ToList()));

        CreateMap<CreateBrandDto, Brand>();
    }
}
