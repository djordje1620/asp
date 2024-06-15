using Rentaly.Application.DTOs.Search;
using Rentaly.Application.DTOs.Users;

namespace Rentaly.Application.UseCases.Queries.Users;
public interface IGetProfileInfoQuery : IQuery<BaseSearch,UserProfileDto>
{
}
