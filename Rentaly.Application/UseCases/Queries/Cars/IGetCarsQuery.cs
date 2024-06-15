using Rentaly.Application.DTOs.Cars;
using Rentaly.Application.DTOs.Search;

namespace Rentaly.Application.UseCases.Queries.Cars;
public interface IGetCarsQuery : IQuery<CarPagedSearchDto, PagedResponse<CarDto>>
{
}
