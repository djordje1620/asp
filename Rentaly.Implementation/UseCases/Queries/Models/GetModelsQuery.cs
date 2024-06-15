using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rentaly.Application.DTOs.Models;
using Rentaly.Application.DTOs.Search;
using Rentaly.Application.UseCases.Queries;
using Rentaly.Application.UseCases.Queries.Models;
using Rentaly.DataAccess;
using Rentaly.Domain.Entities;

namespace Rentaly.Implementation.UseCases.Queries.Models;
public class GetModelsQuery : EfUseCase, IGetModelsQuery
{
    private readonly IMapper _mapper;
    public GetModelsQuery(RentalyDbContext context, IMapper mapper) : base(context)
    {
        _mapper = mapper;
    }

    public int Id => 21;

    public string Name => "Get all models.";

    public string Description => "Get all models using EF.";

    public PagedResponse<ModelDto> Execute(ModelPagedSearch request)
    {
        IQueryable<Model> query = Context.Models.Include(x => x.Cars).Include(x => x.Brand);

        if (!string.IsNullOrEmpty(request.Keyword))
        {
            query = query.Where(x => x.Name.Contains(request.Keyword));
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

        var response = new PagedResponse<ModelDto>();

        response.TotalCount = query.Count();

        response.Data = query.Skip(toSkip)
                             .Take(request.PerPage.Value)
                             .Select(query => _mapper.Map<ModelDto>(query));
                             
        response.CurrentPage = request.Page.Value;

        response.ItemsPerPage = request.PerPage.Value;

        return response;
    }
}
