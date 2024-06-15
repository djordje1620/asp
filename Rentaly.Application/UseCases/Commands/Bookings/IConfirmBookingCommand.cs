using Rentaly.Application.DTOs.Bookings;

namespace Rentaly.Application.UseCases.Commands.Bookings;
public interface IConfirmBookingCommand : ICommand<CompleteBookingDto>
{
}
