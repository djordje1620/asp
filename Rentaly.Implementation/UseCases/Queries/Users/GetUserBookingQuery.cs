using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rentaly.Application;
using Rentaly.Application.DTOs.Bookings;
using Rentaly.Application.UseCases.Queries;
using Rentaly.Application.UseCases.Queries.Bookings;
using Rentaly.DataAccess;
using Rentaly.Domain.Entities;

namespace Rentaly.Implementation.UseCases.Queries.Users;
public class GetUserBookingQuery(RentalyDbContext context, IMapper mapper, IApplicationActor user) 
    : EfUseCase(context), IGetUserBookingQuery
{
    private readonly IMapper _mapper = mapper;
    private readonly IApplicationActor _user = user;
    public int Id => 31;

    public string Name => "Get all Booking for logged in user";

    public string Description => "Get all Booking for logged in user using Ef";

    public PagedResponse<BookingDto> Execute(BookingPagedSearchDto request)
    {
        IQueryable<Booking> query = Context.Bookings.Include(x => x.Car)
                                                    .ThenInclude(x => x.Model)
                                                    .ThenInclude(x => x.Brand)
                                                    .Include(x => x.User)
                                                    .Where(x => x.UserId == _user.Id);

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
