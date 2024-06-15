namespace Rentaly.Application.DTOs.Search;
public class AuditLogSearchDto : CarPagedSearchDto
{
    public string? Identity { get; set; }
    public DateTime? DateStart { get; set; }
    public DateTime? DateEnd { get; set; }
}
