using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rentaly.Application.DTOs.Bookings;
using Rentaly.Application.Exceptions;
using Rentaly.Application.UseCases.Queries.Bookings;
using Rentaly.DataAccess;

namespace Rentaly.Implementation.UseCases.Queries.Bookings;
public class FindBookingQuery : EfUseCase, IFindBookingQuery
{
    private readonly IMapper _mapper;
    public FindBookingQuery(RentalyDbContext context, IMapper mapper) : base(context)
    {
        _mapper = mapper;
    }

    public int Id => 28;

    public string Name => "Find booking by ID";

    public string Description => "Find booking by ID using EF";

    public BookingDto Execute(int request)
    {
        var booking = Context.Bookings.Include(x => x.Car)
                                      .ThenInclude(x => x.Model)
                                      .ThenInclude(x => x.Brand)
                                      .Include(x => x.User)
                                      .FirstOrDefault(x => x.Id == request);

        if (booking is null)
            throw new EntityNotFoundException($"Entity with ID {request} not found.");

        var response = _mapper.Map<BookingDto>(booking);

        return response;
    }
}
