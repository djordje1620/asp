using FluentValidation;
using Rentaly.Application.DTOs.Cars;
using Rentaly.DataAccess;

namespace Rentaly.Implementation.Validators.Cars;
public class CreateCarSpecificationValidator : AbstractValidator<CreateCarSpecificationDto>
{
    private readonly RentalyDbContext _rentalyDbContext;

    public CreateCarSpecificationValidator(RentalyDbContext rentalyDbContext)
    {
        _rentalyDbContext = rentalyDbContext;

        RuleFor(x => x.SpecificationId)
            .NotEmpty().WithMessage("SpecificationId cannot be empty.")
            .Must(BeExistingSpecification).WithMessage("SpecificationId does not exist in the database.");
    }

    private bool BeExistingSpecification(int specificationId)
    {
        return _rentalyDbContext.CarSpecifications.Any(x => x.SpecificationId == specificationId);
    }
}