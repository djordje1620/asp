using Rentaly.Application.DTOs;
using Rentaly.Application.DTOs.Search;

namespace Rentaly.Application.UseCases.Queries;
public interface IGetAuditLogQuery : IQuery<AuditLogSearchDto, PagedResponse<AuditLogDto>>
{

}
