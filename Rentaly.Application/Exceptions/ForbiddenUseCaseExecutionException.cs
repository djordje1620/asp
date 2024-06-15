namespace Rentaly.Application.Exceptions;
public class ForbiddenUseCaseExecutionException : Exception
{
    public ForbiddenUseCaseExecutionException(string useCaseName, string identity) :
        base($"User {identity} has tried to execute {useCaseName} without authorization.")
    {

    }
}
