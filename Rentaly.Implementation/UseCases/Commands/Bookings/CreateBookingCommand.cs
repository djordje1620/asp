using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Rentaly.Application;
using Rentaly.Application.Constant;
using Rentaly.Application.DTOs.Bookings;
using Rentaly.Application.UseCases.Commands.Bookings;
using Rentaly.DataAccess;
using Rentaly.Domain.Entities;
using Rentaly.Implementation.Validators.Bookings;

namespace Rentaly.Implementation.UseCases.Commands.Bookings;
public class CreateBookingCommand(RentalyDbContext context,
    CreateBookingValidator validator, IMapper mapper, IApplicationActor user) : EfUseCase(context), ICreateBookingCommand
{
    private readonly CreateBookingValidator _validator = validator;
    private readonly IMapper _mapper = mapper;
    private readonly IApplicationActor _user = user;

    public int Id => 8;

    public string Name => "Create booking command";

    public string Description => "Create booking command using EF";

    public void Execute(CreateBookingDto request)
    {
        _validator.ValidateAndThrow(request);

        var booking = _mapper.Map<Booking>(request);

        var price = Context.Cars.Include(x => x.Prices)
                                .FirstOrDefault(x => x.Id == request.CarId)!
                                .Prices.First(x => x.DeletedAt == null).PricePerDay;

        var startDate = new DateTime(request.FromDate.Year, request.FromDate.Month, request.FromDate.Day);
        var endDate = new DateTime(request.ToDate.Year, request.ToDate.Month, request.ToDate.Day);

        var numberOfBookingDay = endDate.Subtract(startDate).TotalDays;

        var totalPrice = price * (int)numberOfBookingDay;

        if (request.CarAccessoryIds.Count() > 3)
            totalPrice += Constants.AdditionalFeeForMoreThan3Accessories;

        booking.TotalPrice = totalPrice;

        Context.Add(booking);
        Context.SaveChanges();
    }

}
