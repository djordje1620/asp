using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rentaly.Application.DTOs.Cars;
using Rentaly.Application.Exceptions;
using Rentaly.Application.UseCases.Queries.Cars;
using Rentaly.DataAccess;

namespace Rentaly.Implementation.UseCases.Queries.Cars;
public class FindCarQuery : EfUseCase, IFindCarQuery
{
    private readonly IMapper _mapper;
    public FindCarQuery(RentalyDbContext context, IMapper mapper) : base(context)
    {
        _mapper = mapper;
    }

    public int Id => 26;

    public string Name => "Find car by ID";

    public string Description => "Find car by ID using EF";

    public CarDto Execute(int request)
    {
        var carEntity = Context.Cars.Include(x => x.Type)
                                            .Include(x => x.Prices)
                                            .Include(x => x.Model)
                                                .ThenInclude(x => x.Brand)
                                            .Include(x => x.Reviews)
                                                .ThenInclude(x => x.User)
                                            .Include(x => x.CarSpecifications)
                                                .ThenInclude(x => x.Specification)
                                            .FirstOrDefault(c => c.Id == request);

        if (carEntity is null)
            throw new EntityNotFoundException($"Entity with ID {request} not found.");

        var response = _mapper.Map<CarDto>(carEntity);

        return response;
    }
}
