using Rentaly.Application.UseCases.Logging;
using Rentaly.DataAccess;
using Rentaly.Domain.Entities;


namespace Rentaly.Implementation.UseCases.Logging;
public class DatabaseUseCaseLogger : IUseCaseLogger
{
    private RentalyDbContext _context;

    public DatabaseUseCaseLogger(RentalyDbContext context)
    {
        _context = context;
    }

    public void Log(UseCaseLog log)
    {
        _context.AuditLogs.Add(new AuditLog
        {
            UserId = log.UserId,
            Identity = log.Identity,
            IsAuthorized = log.IsAuthorized,
            Data = log.Data,
            UseCaseName = log.UseCaseName,
            ExecutionDateTime = log.ExecutionDateTime
        });

        _context.SaveChanges();
    }
}
