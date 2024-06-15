using Rentaly.Application.DTOs.Bookings;

namespace Rentaly.Application.UseCases.Queries.Bookings;
public interface IGetBookingsQuery : IQuery<BookingPagedSearchDto, PagedResponse<BookingDto>>
{
}
