using FluentValidation;
using Rentaly.Application.DTOs.Users;
using Rentaly.DataAccess;

namespace Rentaly.Implementation.Validators.Users;
public class CreateUserValidator : AbstractValidator<CreateUserDto>
{
    private readonly RentalyDbContext _dbContext;

    public CreateUserValidator(RentalyDbContext dbContext)
    {
        _dbContext = dbContext;

        RuleFor(x => x.FirstName)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().When(x => x.FirstName != null).WithMessage("FirstName cannot be empty.")
            .Matches(@"^[A-Za-z]+$").When(x => x.FirstName != null).WithMessage("Invalid format for FirstName. Only letters are allowed.");

        RuleFor(x => x.LastName)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().When(x => x.LastName != null).WithMessage("LastName cannot be empty.")
            .Matches(@"^[A-Za-z]+$").When(x => x.LastName != null).WithMessage("Invalid format for LastName. Only letters are allowed.");

        RuleFor(x => x.Email)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().When(x => x.Email != null).WithMessage("Email cannot be empty.")
            .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$").When(x => x.Email != null).WithMessage("Invalid format for Email.")
            .Must(BeUniqueEmail).WithMessage("Email already exists in the database.");

        RuleFor(x => x.UserName)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().When(x => x.UserName != null).WithMessage("UserName cannot be empty.")
            .Matches(@"^[a-zA-Z0-9_]+$").When(x => x.UserName != null).WithMessage("Invalid format for UserName. Only letters, digits, and underscores are allowed.")
            .Length(4, 20).When(x => x.UserName != null).WithMessage("UserName must be between 4 and 20 characters.")
            .Must(BeUniqueUsername).WithMessage("UserName already exists in the database.");

        RuleFor(x => x.Password)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().When(x => x.Password != null).WithMessage("Password cannot be empty.")
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$")
            .When(x => x.Password != null).WithMessage("Password must be between 8 and 15 characters and contain at least one uppercase letter, one lowercase letter, one digit, and one special character.");
    }

    private bool BeUniqueEmail(string email)
    {
        return !_dbContext.Users.Any(x => x.Email == email);
    }

    private bool BeUniqueUsername(string username)
    {
        return !_dbContext.Users.Any(x => x.UserName == username);
    }
}

