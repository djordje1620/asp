using FluentValidation;
using Rentaly.Application.DTOs.Cars;
using Rentaly.DataAccess;
namespace Rentaly.Implementation.Validators.Cars;
public class CreateCarValidator : AbstractValidator<CreateCarDto>
{
    private readonly RentalyDbContext _rentalyDbContext;

    public CreateCarValidator(RentalyDbContext rentalyDbContext)
    {
        _rentalyDbContext = rentalyDbContext;

        RuleFor(x => x.ImagePath)
            .NotEmpty().WithMessage("ImagePath cannot be empty.");

        RuleFor(x => x.ManufacturerYear)
            .Must(year => year.Year > 2000).WithMessage("ManufacturerYear must be greater than 2000.");

        RuleFor(x => x.ModelId)
            .NotEmpty().WithMessage("ModelId cannot be empty.")
            .Must(BeExistingModel).WithMessage("ModelId does not exist in the database.");

        RuleFor(x => x.TypeId)
            .NotEmpty().WithMessage("TypeId cannot be empty.")
            .Must(BeExistingType).WithMessage("TypeId does not exist in the database.");

        RuleFor(x => x.PricePerDay)
            .GreaterThanOrEqualTo(5).WithMessage("PricePerDay cannot be less than 5.");

        RuleFor(dto => dto.CarSpecifications)
            .Must(specs => specs.All(spec => spec.SpecificationId > 0)).WithMessage("SpecificationId must be greater than 0.")
            .Must((dto, specs) => specs.All(spec => SpecificationExistsInDatabase(spec.SpecificationId))).WithMessage("Some specifications do not exist in the database.");
    }

    private bool BeExistingModel(int modelId)
    {
        return _rentalyDbContext.Models.Any(x => x.Id == modelId);
    }

    private bool BeExistingType(int typeId)
    {
        return _rentalyDbContext.CarTypes.Any(x => x.Id == typeId);
    }

    private bool SpecificationExistsInDatabase(int specificationId)
    {
        
        return _rentalyDbContext.Specifications.Any(spec => spec.Id == specificationId);
    }
}