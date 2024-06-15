using Rentaly.Application.DTOs.Models;
using Rentaly.Application.DTOs.Search;

namespace Rentaly.Application.UseCases.Queries.Models;
public interface IGetModelsQuery : IQuery<ModelPagedSearch, PagedResponse<ModelDto>>
{
}
