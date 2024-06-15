using Rentaly.Application.DTOs.Bookings;


namespace Rentaly.Application.UseCases.Queries.Bookings;
public interface IGetUserBookingQuery : IQuery<BookingPagedSearchDto, PagedResponse<BookingDto>>
{
}
