using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rentaly.Application.Constant;
using Rentaly.Application.DTOs.Cars;
using Rentaly.Application.DTOs.Search;
using Rentaly.Application.UseCases.Queries;
using Rentaly.Application.UseCases.Queries.Cars;
using Rentaly.DataAccess;
using Rentaly.Domain.Entities;

namespace Rentaly.Implementation.UseCases.Queries.Cars;
public class GetCarsQuery : EfUseCase, IGetCarsQuery
{
    private readonly IMapper _mapper;
    public GetCarsQuery(RentalyDbContext context, IMapper mapper) : base(context)
    {
        _mapper = mapper;
    }

    public int Id => 25;

    public string Name => "Get all cars.";

    public string Description => "Get all cars using EF.";

    public PagedResponse<CarDto> Execute(CarPagedSearchDto request)
    {
        IQueryable<Car> query = Context.Cars.Include(x => x.Type)
                                            .Include(x => x.Prices)
                                            .Include(x => x.Model)
                                                .ThenInclude(x => x.Brand)
                                            .Include(x => x.Reviews)
                                                .ThenInclude(x => x.User)
                                            .Include(x => x.CarSpecifications)
                                                .ThenInclude(x => x.Specification);

        if (!string.IsNullOrEmpty(request.Keyword))
        {
            query = query.Where(car => car.Model.Name.Contains(request.Keyword) ||
                                             car.Model.Brand.Name.Contains(request.Keyword));
        }

        if (request.YearFrom.HasValue)
        {
            query = query.Where(c => c.ManufacturerYear >= request.YearFrom);
        }

        if (request.YearTo.HasValue)
        {
            query = query.Where(c => c.ManufacturerYear <= request.YearTo);
        }

        if (!string.IsNullOrWhiteSpace(request.VIN))
        {
            query = query.Where(c => c.VIN == request.VIN);
        }

        if (request.MoreThenKilometars.HasValue)
        {
            query = query.Where(c => c.Kilometars > request.MoreThenKilometars);
        }

        if (request.LessTheKilometars.HasValue)
        {
            query = query.Where(c => c.Kilometars < request.LessTheKilometars);
        }

        if (request.CarType != null && request.CarType.Any())
        {
            query = query.Where(c => request.CarType.Contains(c.TypeId));
        }

        if (!string.IsNullOrWhiteSpace(request.SortBy))
        {
            if (request.SortBy.Equals(Constants.Price_ASC, StringComparison.OrdinalIgnoreCase))
            {
                query = query.OrderBy(c => c.Prices.Min(p => p.PricePerDay));
            }
            else if (request.SortBy.Equals(Constants.Price_DESC, StringComparison.OrdinalIgnoreCase))
            {
                query = query.OrderByDescending(c => c.Prices.Min(p => p.PricePerDay));
            }
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



        var response = new PagedResponse<CarDto>();

        response.TotalCount = query.Count();

        response.Data = query.Skip(toSkip)
                             .Take(request.PerPage.Value)
                             .Select(query => _mapper.Map<CarDto>(query))
                             .ToList();

        response.CurrentPage = request.Page.Value;

        response.ItemsPerPage = request.PerPage.Value;

        return response;
    }
}
