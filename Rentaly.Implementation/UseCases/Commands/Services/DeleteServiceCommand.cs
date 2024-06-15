using Rentaly.Application.Exceptions;
using Rentaly.Application.UseCases.Commands.Services;
using Rentaly.DataAccess;

namespace Rentaly.Implementation.UseCases.Commands.Services;
public class DeleteServiceCommand : EfUseCase, IDeleteServiceCommand
{
    public DeleteServiceCommand(RentalyDbContext context) : base(context)
    {
    }

    public int Id => 19;

    public string Name => "Delete Service command";

    public string Description => "Delete Service command using Ef";

    public void Execute(int request)
    {
        var serviceForDelete = Context.CarServices.Find(request);

        if (serviceForDelete is null)
            throw new EntityNotFoundException($"Entity with ID {request} not found.");

        Context.Remove(serviceForDelete);

        Context.SaveChanges();
    }
}
