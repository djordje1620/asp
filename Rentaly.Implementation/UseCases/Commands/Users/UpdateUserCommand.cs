using Rentaly.Application.DTOs.Users;
using Rentaly.Application.Exceptions;
using Rentaly.Application.UseCases.Commands.Users;
using Rentaly.DataAccess;
using Rentaly.Implementation.Validators.Users;
using FluentValidation;
using Rentaly.Domain.Entities;
using Rentaly.Application;

namespace Rentaly.Implementation.UseCases.Commands.Users;
public class UpdateUserCommand(RentalyDbContext context, UpdateUserValidator validator, IApplicationActor user)
    : EfUseCase(context), IUpdateUserCommand
{
    private readonly UpdateUserValidator _validator = validator;
    private readonly IApplicationActor _user = user;

    public int Id => 18;

    public string Name => "Update User command";

    public string Description => "Update User command using Ef";

    public void Execute(UpdateUserDto request)
    {
        _validator.ValidateAndThrow(request);

        var userForUpdate = Context.Users.Find(request.Id);

        if (userForUpdate is null)
            throw new EntityNotFoundException($"Entity with ID {request} not found.");

        if (userForUpdate.Id != _user.Id)
            throw new ForbiddenAccessException();

        userForUpdate.FirstName = request.FirstName ?? userForUpdate.FirstName;
        userForUpdate.LastName = request.LastName ?? userForUpdate.LastName;
        userForUpdate.Email = request.Email ?? userForUpdate.Email;
        userForUpdate.UserName = request.UserName ?? userForUpdate.UserName;
        userForUpdate.Password = request.Password ?? userForUpdate.Password;

        Context.SaveChanges();
    }
}
