using Rentaly.Application.DTOs.Bookings;

namespace Rentaly.Application.UseCases.Queries.Bookings;
public interface IFindBookingQuery : IQuery<int, BookingDto>
{
}
