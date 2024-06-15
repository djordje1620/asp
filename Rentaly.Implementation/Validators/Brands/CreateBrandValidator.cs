using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Rentaly.Application.DTOs.Brands;
using Rentaly.DataAccess;

namespace Rentaly.Implementation.Validators.Brands;
public class CreateBrandValidator : AbstractValidator<CreateBrandDto>
{
    private readonly RentalyDbContext _context;
    public CreateBrandValidator(RentalyDbContext context)
    {
        _context = context;

        RuleFor(x => x.Name)
           .NotEmpty().WithMessage("Name cannot be empty.")
           .MaximumLength(50).WithMessage("Name must not be longer than 50 characters.")
           .Matches("^[A-Za-z0-9]+$").WithMessage("Name can only contain letters and numbers.")
           .Must(BeUniqueBrand).WithMessage("Name already exists in the database."); ;
    }

    private bool BeUniqueBrand(string name)
    {
        return !_context.Brands.Any(x => x.Name == name);
    }
}