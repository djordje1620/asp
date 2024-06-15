using AutoMapper;
using Rentaly.Application.DTOs.Bookings;
using Rentaly.Domain.Entities;

namespace Rentaly.Implementation.Mappings;
public class BookingProfile : Profile
{
    public BookingProfile()
    {
        CreateMap<Booking, BookingDto>()
           .ForMember(dest => dest.Car, opt => opt.MapFrom(src => new CarInfoDto
           {
               Id = src.CarId,
               ManufacturerYear = src.Car.ManufacturerYear,
               Name = src.Car.Model.Name + " " + src.Car.Model.Brand.Name,
               Kilometars = src.Car.Kilometars
           }))
           .ForMember(dest => dest.User, opt => opt.MapFrom(src => new UserInfoDto
           {
               Id = src.UserId,
               UserName = src.User.UserName,
               UserEmail = src.User.Email
           }));


        CreateMap<CreateBookingDto, Booking>()
          .ForMember(dest => dest.TotalPrice, opt => opt.Ignore()) 
          .ForMember(dest => dest.CarAccessories, opt => opt.MapFrom(src => src.CarAccessoryIds.Select(id => new BookingCarAccessories { CarAccessoryId = id })));
    }
}
