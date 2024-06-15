using Rentaly.Application.DTOs.Brands;
using Rentaly.Application.DTOs.Search;

namespace Rentaly.Application.UseCases.Queries.Brands;
public interface IGetBrandsQuery : IQuery<PagedSearch, PagedResponse<BrandDto>>
{
}
