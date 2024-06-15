using Newtonsoft.Json;
using Rentaly.Application;
using Rentaly.Application.Exceptions;
using Rentaly.Application.Logging;
using Rentaly.Application.UseCases;
using Rentaly.Application.UseCases.Logging;
using System.Diagnostics;

namespace Rentaly.Implementation;
public class UseCaseHandler
{
    private IExceptionLogger _logger;
    private IApplicationActor _user;
    private IUseCaseLogger _useCaseLogger;
    public UseCaseHandler(
        IExceptionLogger logger,
        IApplicationActor user,
        IUseCaseLogger useCaseLogger)
    {
        _logger = logger;
        _user = user;
        _useCaseLogger = useCaseLogger;
    }

    public void HandleCommand<TRequest>(ICommand<TRequest> command, TRequest data)
    {
        try
        {
            HandleLoggingAndAuthorization(command, data);

            var stopwatch = new Stopwatch();
            stopwatch.Start();


            command.Execute(data);

            stopwatch.Stop();

            Console.WriteLine(command.Name + " Duration: " + stopwatch.ElapsedMilliseconds + " ms.");
        }
        catch (Exception ex)
        {
            _logger.Log(ex);
            throw;
        }
    }

    public TResponse HandleQuery<TRequest, TResponse>(IQuery<TRequest, TResponse> query, TRequest data)
    {
        try
        {
            HandleLoggingAndAuthorization(query, data);

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var response = query.Execute(data);

            stopwatch.Stop();

            Console.WriteLine(query.Name + " Duration: " + stopwatch.ElapsedMilliseconds + " ms.");

            return response;
        }
        catch (Exception ex)
        {
            _logger.Log(ex);
            throw;
        }
    }

    private void HandleLoggingAndAuthorization<TRequest>(IUseCase useCase, TRequest data)
    {

        var isAuthorized = _user.AllowedUseCases.Contains(useCase.Id);

        var log = new UseCaseLog
        {
            Identity = _user.Email,
            ExecutionDateTime = DateTime.UtcNow,
            UseCaseName = useCase.Name,
            UserId = _user.Id,
            Data = JsonConvert.SerializeObject(data),
            IsAuthorized = isAuthorized
        };

        _useCaseLogger.Log(log);

        if (!isAuthorized)
        {
            throw new ForbiddenUseCaseExecutionException(useCase.Name, _user.Email);
        }
    }
}
