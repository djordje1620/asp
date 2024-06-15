using FluentValidation;
using Rentaly.Application.DTOs.Models;
using Rentaly.DataAccess;

namespace Rentaly.Implementation.Validators.Models;
public class CreateModelValidator : AbstractValidator<CreateModelDto>
{
    private readonly RentalyDbContext _rentalyDbContext;

    public CreateModelValidator(RentalyDbContext rentalyDbContext)
    {
        _rentalyDbContext = rentalyDbContext;

        RuleFor(x => x.Name)
           .NotEmpty().WithMessage("Name cannot be empty.")
           .MaximumLength(20).WithMessage("Name must not be longer than 20 characters.");

        RuleFor(x => x.BrandId)
            .NotEmpty().WithMessage("Brand ID cannot be empty.")
            .Must(BrandExists)
                .WithMessage("Brand ID does not exist in the database.");
    }

    private bool BrandExists(int brandId)
    {
        return _rentalyDbContext.Brands.Any(x => x.Id == brandId);
    }
}
