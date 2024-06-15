using AutoMapper;
using Rentaly.Application.DTOs.Search;
using Rentaly.Application.DTOs;
using Rentaly.Application.UseCases.Queries;
using Rentaly.Domain.Entities;
using Rentaly.DataAccess;


namespace Rentaly.Implementation.UseCases.Queries;
public class GetAuditLogQuery : EfUseCase, IGetAuditLogQuery
{
    private readonly IMapper _mapper;

    public GetAuditLogQuery(RentalyDbContext context, IMapper mapper) : base(context)
    {
        _mapper = mapper;
    }

    public int Id => 29;
    public string Name => "Get Audit Log information";

    public string Description => "Get Audit log information using EF.";

    public PagedResponse<AuditLogDto> Execute(AuditLogSearchDto request)
    {
        IQueryable<AuditLog> query = Context.AuditLogs;

        if (!string.IsNullOrEmpty(request.Identity))
        {
            query = query.Where(x => x.Identity == request.Identity);
        }

        if (request.DateStart != null)
        {
            query = query.Where(x => x.ExecutionDateTime >= request.DateStart);
        }

        if (request.DateEnd != null)
        {
            query = query.Where(x => x.ExecutionDateTime <= request.DateEnd);
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

        var response = new PagedResponse<AuditLogDto>();
        response.TotalCount = query.Count();

        response.Data = query.Skip(toSkip)
                             .Take(request.PerPage.Value)
                             .Select(query => _mapper.Map<AuditLogDto>(query))
                             .ToList();

        response.CurrentPage = request.Page.Value;

        response.ItemsPerPage = request.PerPage.Value;

        return response;
    }
}
