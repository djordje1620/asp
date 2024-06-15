using AutoMapper;
using Rentaly.Application.DTOs.Models;
using Rentaly.Domain.Entities;

namespace Rentaly.Implementation.Mappings;
public class ModelProfile : Profile
{
    public ModelProfile()
    {
        CreateMap<Model, ModelDto>()
           .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand.Name))
           .ForMember(dest => dest.Cars, opt => opt.MapFrom(src => src.Cars
               .Select(x => new CarDetailsDto
               {
                   Id = x.Id,
                   Name = x.Model.Name + " " + x.Model.Brand.Name
               })
               .ToList()));

        CreateMap<CreateModelDto, Model>();
    }
}
