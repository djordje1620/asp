namespace Rentaly.Application.UseCases;
public interface IQuery<TRequest, TResponse> : IUseCase
{
    TResponse Execute(TRequest request);
}