using Rentaly.Application.DTOs.Services;

namespace Rentaly.Application.UseCases.Queries.Services;
public interface IFindServiceQuery : IQuery<int, ServiceDto>
{
}
