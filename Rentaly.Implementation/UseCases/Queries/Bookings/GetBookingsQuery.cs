using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rentaly.Application.DTOs.Bookings;
using Rentaly.Application.DTOs.Search;
using Rentaly.Application.UseCases.Queries;
using Rentaly.Application.UseCases.Queries.Bookings;
using Rentaly.DataAccess;
using Rentaly.Domain.Entities;

namespace Rentaly.Implementation.UseCases.Queries.Bookings;
public class GetBookingsQuery(RentalyDbContext context, IMapper mapper) : EfUseCase(context), IGetBookingsQuery
{
    private readonly IMapper _mapper = mapper;

    public int Id => 27;

    public string Name => "Get all bookings";

    public string Description => "Get all bookings using Ef";

    public PagedResponse<BookingDto> Execute(BookingPagedSearchDto request)
    {
        IQueryable<Booking> query = Context.Bookings.Include(x => x.Car)
                                                        .ThenInclude(x => x.Model)
                                                        .ThenInclude(x => x.Brand)
                                                    .Include(x => x.User);

        if (!string.IsNullOrEmpty(request.Keyword))
        {
            query = query.Where(booking => booking.Car.Model.Name.Contains(request.Keyword) ||
                                       booking.Car.Model.Brand.Name.Contains(request.Keyword) ||
                                       booking.User.Email.Contains(request.Keyword));
        }

        if (request.FromDate.HasValue)
        {
            query = query.Where(c => c.FromDate >= request.FromDate);
        }

        if (request.ToDate.HasValue)
        {
            query = query.Where(c => c.ToDate >= request.ToDate);
        }


        if (request.UserIds != null && request.UserIds.Any())
        {
            query = query.Where(c => request.UserIds.Contains(c.UserId));
        }

        if (request.PerPage == null || request.PerPage < 1)
        {
            request.PerPage = 15;
        }

        if (request.Page == null || request.Page < 1)
        {
            request.Page = 15;
        }

        var toSkip = (request.Page.Value - 1) * request.PerPage.Value;

        var response = new PagedResponse<BookingDto>();

        response.TotalCount = query.Count();

        response.Data = query.Skip(toSkip)
                             .Take(request.PerPage.Value)
                             .Select(query => _mapper.Map<BookingDto>(query));

        response.CurrentPage = request.Page.Value;

        response.ItemsPerPage = request.PerPage.Value;

        return response;
    }
}
