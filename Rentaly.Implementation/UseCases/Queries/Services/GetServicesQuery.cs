using Microsoft.EntityFrameworkCore;
using Rentaly.Application.DTOs.Search;
using Rentaly.Application.DTOs.Services;
using Rentaly.Application.UseCases.Queries;
using Rentaly.Application.UseCases.Queries.Services;
using Rentaly.DataAccess;
using Rentaly.Domain.Entities;

namespace Rentaly.Implementation.UseCases.Queries.Services;
public class GetServicesQuery : EfUseCase, IGetServicesQuery
{
    public GetServicesQuery(RentalyDbContext context) : base(context)
    {
    }

    public int Id => 32;

    public string Name => "Get all services query";

    public string Description => "Get all services query using Ef";

    public PagedResponse<ServiceDto> Execute(ServicePagedSearchDto request)
    {
        IQueryable<CarService> query = Context.CarServices.Include(x => x.Car).ThenInclude(x => x.Model).ThenInclude(x => x.Brand);

        if (!string.IsNullOrEmpty(request.Keyword))
        {
            query = query.Where(x => x.Car.Model.Name.Contains(request.Keyword));
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

        var response = new PagedResponse<ServiceDto>();

        response.TotalCount = query.Count();

        response.Data = query.Skip(toSkip)
                             .Take(request.PerPage.Value)
                             .Select(query => new ServiceDto
                             {
                                 Id = query.Id,
                                 ServiceName = query.ServiceName,
                                 Description = query.Description,
                                 FromDate = query.FromDate,
                                 ToDate = query.ToDate,
                                 Car = query.Car.Model.Name + " VIN number: " + query.Car.VIN,
                                 ServiceType = query.ServiceType.ToString(),
                             });

        response.CurrentPage = request.Page.Value;

        response.ItemsPerPage = request.PerPage.Value;

        return response;
    }
}


