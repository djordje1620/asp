using FluentValidation;
using Rentaly.Application.DTOs.Services;
using Rentaly.DataAccess;

namespace Rentaly.Implementation.Validators.Services;
public class CreateServiceValidator : AbstractValidator<CreateServiceDto>
{
    private readonly RentalyDbContext _rentalyDbContext;

    public CreateServiceValidator(RentalyDbContext rentalyDbContext)
    {
        _rentalyDbContext = rentalyDbContext;

        RuleFor(x => x.ServiceName)
            .NotEmpty().WithMessage("ServiceName must not be empty.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description must not be empty.");

        RuleFor(x => x.CarId)
            .NotEmpty().WithMessage("CarId cannot be empty.")
            .Must(BeExistingCar).WithMessage("CarId does not exist in the database.");

        RuleFor(x => x.FromDate)
            .Must(BeValidFromDate).WithMessage("FromDate must be at least 7 days from today's date.");

        RuleFor(x => x.ToDate)
            .GreaterThan(x => x.FromDate).WithMessage("ToDate must be greater than FromDate.")
            .Must((dto, toDate) => !HasOverlappingServices(dto.CarId, dto.FromDate, toDate))
                .WithMessage("Another service is already scheduled for the specified car within the specified period.")
            .Must((dto, toDate) => !HasBookingsInPeriod(dto.CarId, dto.FromDate, toDate))
               .WithMessage("There is a booking scheduled for the specified car within the specified period.");
    }

    private bool BeExistingCar(int carId)
    {
        return _rentalyDbContext.Cars.Any(x => x.Id == carId);
    }

    private bool BeValidFromDate(DateOnly fromDate)
    {
        return fromDate >= DateOnly.FromDateTime(DateTime.Today.AddDays(7));
    }

    private bool HasOverlappingServices(int carId, DateOnly fromDate, DateOnly toDate)
    {
        return _rentalyDbContext.CarServices.Any(service =>
            service.CarId == carId && !(toDate < service.FromDate || fromDate > service.ToDate));
    }

    private bool HasBookingsInPeriod(int carId, DateOnly fromDate, DateOnly toDate)
    {
        return _rentalyDbContext.Bookings.Any(booking =>
            booking.CarId == carId &&
            !(toDate < booking.FromDate || fromDate > booking.ToDate));
    }
}

