using FluentValidation;
using Rentaly.Application.DTOs.Bookings;
using Rentaly.Application.Exceptions;
using Rentaly.Application.UseCases.Commands.Bookings;
using Rentaly.DataAccess;
using Rentaly.Domain.Entities;
using Rentaly.Implementation.Validators.Bookings;

namespace Rentaly.Implementation.UseCases.Commands.Bookings;
public class CompleteBookingCommand : EfUseCase, IConfirmBookingCommand
{
    private readonly CompleteBookingValidator _validator;
    public CompleteBookingCommand(RentalyDbContext context, CompleteBookingValidator validator) : base(context)
    {
        _validator = validator;
    }

    public int Id => 12;

    public string Name => "Complete booking command";

    public string Description => "Complete booking command using EF";

    public void Execute(CompleteBookingDto request)
    {
        _validator.ValidateAndThrow(request);

        var booking = Context.Bookings.Find(request.Id);

        if (booking is null)
            throw new EntityNotFoundException($"Entity with ID {request} not found.");

        booking.Status = BookingStatus.Completed.ToString();
        
        var car = Context.Cars.Find(booking.CarId);
        car.Kilometars = request.Kilometars;

        Context.SaveChanges();
    }
}
