using Rentaly.Application.DTOs.Search;
using Rentaly.Application.DTOs.Services;

namespace Rentaly.Application.UseCases.Queries.Services;
public interface IGetServicesQuery : IQuery<ServicePagedSearchDto, PagedResponse<ServiceDto>>
{
}
