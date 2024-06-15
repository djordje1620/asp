namespace Rentaly.Application.DTOs;
public class AuditLogDto
{
    public int UserId { get; set; }
    public string Identity { get; set; }
    public string UseCaseName { get; set; }
    public DateTime ExecutionDateTime { get; set; }
    public bool IsAuthorized { get; set; }
    public string Data { get; set; }
}
