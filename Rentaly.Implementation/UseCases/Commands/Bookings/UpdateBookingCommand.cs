using Rentaly.Application.DTOs.Bookings;
using Rentaly.Application.Exceptions;
using Rentaly.Application.UseCases.Commands.Bookings;
using Rentaly.DataAccess;
using Rentaly.Implementation.Validators.Bookings;

namespace Rentaly.Implementation.UseCases.Commands.Bookings;
public class UpdateBookingCommand : EfUseCase, IUpdateBookingCommand
{
    private readonly UpdateBookingValidator _validator;
    public UpdateBookingCommand(RentalyDbContext context, UpdateBookingValidator validator) : base(context)
    {
        _validator = validator;
    }

    public int Id => 9;

    public string Name => "Update booking command";

    public string Description => "Update booking command using Ef";

    public void Execute(UpdateBookingDto request)
    {
        _validator.Validate(request);

        var booking = Context.Bookings.Find(request.Id);

        if(booking is null)
            throw new EntityNotFoundException($"Entity with ID {request} not found.");

        booking.FromDate = request.FromDate;
        booking.ToDate = request.ToDate;

        Context.SaveChanges();
    }
}
