using AutoMapper;
using Rentaly.Application.DTOs.Services;
using Rentaly.Domain.Entities;


namespace Rentaly.Implementation.Mappings;
public class ServiceProfile : Profile
{
    public ServiceProfile()
    {
        CreateMap<CreateServiceDto, CarService>();

        CreateMap<CarService, ServiceDto>()
                .ForMember(dest => dest.Car, opt => opt.MapFrom(src => $"{src.Car.Model.Name} VIN number: {src.Car.VIN}"));
    }
}
