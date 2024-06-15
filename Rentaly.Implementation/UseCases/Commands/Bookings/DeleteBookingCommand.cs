using Rentaly.Application;
using Rentaly.Application.Constant;
using Rentaly.Application.Exceptions;
using Rentaly.Application.UseCases.Commands.Bookings;
using Rentaly.DataAccess;
using Rentaly.Domain.Entities;

namespace Rentaly.Implementation.UseCases.Commands.Bookings;
public class DeleteBookingCommand(RentalyDbContext context, IApplicationActor user) : EfUseCase(context), IDeleteBookingCommand
{
    private IApplicationActor _user = user;

    public int Id => 10;

    public string Name => "Delete booking command";

    public string Description => "Delete booking command using EF";

    public void Execute(int request)
    {
        var booking = Context.Bookings.Find(request);

        if (booking is null)
            throw new EntityNotFoundException($"Entity with ID {request} not found.");

        if (booking.UserId != _user.Id && _user.RoleName != Constants.Admin)
            throw new ForbiddenAccessException();

        Context.Bookings.Remove(booking);

        Context.SaveChanges();
    }
}
