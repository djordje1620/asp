using AutoMapper;
using FluentValidation;
using Rentaly.Application.DTOs.Users;
using Rentaly.Application.UseCases.Commands.Users;
using Rentaly.DataAccess;
using Rentaly.Domain.Entities;
using Rentaly.Implementation.Validators.Users;

namespace Rentaly.Implementation.UseCases.Commands.Users;
public class CreateUserCommand(RentalyDbContext context, CreateUserValidator validator, IMapper mapper)
    : EfUseCase(context), ICreateUserCommand
{
    private readonly CreateUserValidator _validator = validator;
    private readonly IMapper _mapper = mapper;

    public int Id => 34;

    public string Name => "Create new User";

    public string Description => "Create new User";

    public void Execute(CreateUserDto request)
    {
        _validator.ValidateAndThrow(request);

        var user = _mapper.Map<User>(request);

        Context.Users.Add(user);
        Context.SaveChanges();
    }
}
