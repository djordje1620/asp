using Rentaly.Application;
using Rentaly.Application.Constant;
using Rentaly.Application.Exceptions;
using Rentaly.Application.UseCases.Commands.Users;
using Rentaly.DataAccess;
using Rentaly.Domain.Entities;

namespace Rentaly.Implementation.UseCases.Commands.Users;
public class DeleteUserCommand(RentalyDbContext context, IApplicationActor user) : EfUseCase(context), IDeleteUserCommand
{
    private readonly IApplicationActor _user = user;

    public int Id => 17;

    public string Name => "Delete user command";

    public string Description => "Delete user command using Ef";

    public void Execute(int request)
    {
        var userForDelete = Context.Users.Find(request);

        if (userForDelete is null)
            throw new EntityNotFoundException($"Entity with ID {request} not found.");

        if (userForDelete.Id != _user.Id && _user.RoleName != Constants.Admin)
            throw new ForbiddenAccessException();

        Context.Remove(userForDelete);

        Context.SaveChanges();
    }
}
