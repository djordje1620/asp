using Rentaly.Application.Exceptions;
using Rentaly.Application.UseCases.Commands.Bookings;
using Rentaly.DataAccess;
using Rentaly.Domain.Entities;

namespace Rentaly.Implementation.UseCases.Commands.Bookings;
public class StartBookingCommand : EfUseCase, IStartBookingCommand
{
    public StartBookingCommand(RentalyDbContext context) : base(context)
    {
    }

    public int Id => 11;

    public string Name => "Start booking command";

    public string Description => "Start booking command using EF";

    public void Execute(int request)
    {
        var booking = Context.Bookings.Find(request);

        if (booking is null)
            throw new EntityNotFoundException($"Entity with ID {request} not found.");

        booking.Status = BookingStatus.InProgres.ToString();

        Context.SaveChanges();
    }
}
