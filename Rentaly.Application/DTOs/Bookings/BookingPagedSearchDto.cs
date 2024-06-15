using Rentaly.Application.DTOs.Search;

namespace Rentaly.Application.DTOs.Bookings;
public class BookingPagedSearchDto : PagedSearch
{
    public string? Keyword { get; set; }
    public DateOnly? FromDate { get; set; }
    public DateOnly? ToDate { get; set; }
    public IEnumerable<int>? CarId { get; set; }
    public IEnumerable<int>? UserIds { get; set; }
}
