using FluentValidation;
using Rentaly.Application.DTOs.Cars;

namespace Rentaly.Implementation.Validators.Cars;
public class UpdateCarValidator : AbstractValidator<UpdateCarDto>
{
    public UpdateCarValidator()
    {
        RuleFor(dto => dto.PricePerDay)
            .GreaterThan(0).WithMessage("Price per day must be greater than 0.");
    }
}
