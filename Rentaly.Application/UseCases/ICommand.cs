namespace Rentaly.Application.UseCases;
public interface ICommand<TRequest> : IUseCase
{
    void Execute(TRequest request);
}
