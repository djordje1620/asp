using Rentaly.Application.DTOs.Search;
using Rentaly.Application.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentaly.Application.UseCases.Queries.Users;
public interface IGetUsersQuery : IQuery<UserPagedSearchDto, PagedResponse<UserProfileDto>>
{
}
