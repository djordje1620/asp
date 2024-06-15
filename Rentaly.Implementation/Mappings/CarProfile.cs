using AutoMapper;
using Rentaly.Application.DTOs.Cars;
using Rentaly.Domain.Entities;

namespace Rentaly.Implementation.Mappings;
public class CarProfile : Profile
{
    public CarProfile()
    {
        CreateMap<Car, CarDto>()
            .ForMember(dest => dest.ManufacturerYear, opt => opt.MapFrom(src => src.ManufacturerYear.Year))
            .ForMember(dest => dest.Kilometars, opt => opt.MapFrom(src => src.Kilometars + " KM"))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Model.Brand.Name + " " + src.Model.Name))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.Name))
            .ForMember(dest => dest.PricePerDay, opt => opt.MapFrom(src => src.Prices.FirstOrDefault(x => x.DeletedAt == null)!.PricePerDay + " USD"))
            .ForMember(dest => dest.StarsRate, opt => opt.MapFrom(src => src.Reviews.Any() ? src.Reviews.Select(x => x.StarsRate).Average() : 0))
            .ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src.Reviews.Select(x => new ReviewDto
            {
                Id = x.Id,
                Stars = x.StarsRate,
                Comment = x.Comment,
                User = x.User.UserName
            })))
            .ForMember(dest => dest.Specifications, opt => opt.MapFrom(src => src.CarSpecifications.Select(x => new SpecificationDto
            {
                Id = x.SpecificationId,
                Name = x.Specification.Name,
                Value = x.Value
            })));

        CreateMap<CreateCarDto, Car>()
             .ForMember(dest => dest.CarSpecifications, opt => opt.MapFrom(src => src.CarSpecifications.Select(spec => new CarSpecification
             {
                 SpecificationId = spec.SpecificationId,
                 Value = spec.Value
             }).ToList()))
             .ForMember(dest => dest.Prices, opt => opt.MapFrom(src => new List<Price>
             {
                new Price
                {
                    PricePerDay = src.PricePerDay
                }
             }));
    }
}
