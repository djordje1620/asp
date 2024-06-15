using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rentaly.Application.DTOs.Brands;
using Rentaly.Application.DTOs.Search;
using Rentaly.Application.UseCases.Queries;
using Rentaly.Application.UseCases.Queries.Brands;
using Rentaly.DataAccess;
using Rentaly.Domain.Entities;

namespace Rentaly.Implementation.UseCases.Queries.Brands;
public class GetBrandsQuery : EfUseCase, IGetBrandsQuery
{
    private readonly IMapper _mapper;
    public GetBrandsQuery(RentalyDbContext context,IMapper mapper) : base(context)
    {
        _mapper = mapper;
    }

    public int Id => 23;

    public string Name => "Get all brands";

    public string Description => "Get all brands using EF";

    public PagedResponse<BrandDto> Execute(PagedSearch request)
    {
        IQueryable<Brand> query = Context.Brands.Include(x => x.Models);

        if (request.PerPage == null || request.PerPage < 1)
        {
            request.PerPage = 15;
        }

        if (request.Page == null || request.Page < 1)
        {
            request.Page = 15;
        }

        var toSkip = (request.Page.Value - 1) * request.PerPage.Value;

        var response = new PagedResponse<BrandDto>();

        response.TotalCount = query.Count();

        response.Data = query.Skip(toSkip)
                             .Take(request.PerPage.Value)
                             .Select(query => _mapper.Map<BrandDto>(query));

        response.CurrentPage = request.Page.Value;

        response.ItemsPerPage = request.PerPage.Value;

        return response;
    }
}
