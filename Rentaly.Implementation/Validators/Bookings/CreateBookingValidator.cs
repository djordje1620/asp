using FluentValidation;
using Rentaly.Application.DTOs.Bookings;
using Rentaly.DataAccess;
using Rentaly.Domain.Entities;

namespace Rentaly.Implementation.Validators.Bookings;
public class CreateBookingValidator : AbstractValidator<CreateBookingDto>
{
    private readonly RentalyDbContext _rentalyDbContext;

    public CreateBookingValidator(RentalyDbContext rentalyDbContext)
    {
        _rentalyDbContext = rentalyDbContext;

        RuleFor(x => x.FromDate)
        .NotEmpty().WithMessage("FromDate cannot be empty.")
        .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today.AddDays(7))).WithMessage("FromDate must be at least 7 days from today's date.");

        RuleFor(x => x.ToDate)
            .NotEmpty().WithMessage("ToDate cannot be empty.")
            .GreaterThan(x => x.FromDate).WithMessage("ToDate must be greater than FromDate.");

        RuleFor(x => x.CarId)
        .NotEmpty().WithMessage("CarId cannot be empty.")
        .Must(BeExistingCar).WithMessage("CarId does not exist in the database.")
        .Must((dto, carId) => IsCarAvailableInRange(carId, dto.FromDate, dto.ToDate)).WithMessage("Car is not available in the specified date range.");

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId cannot be empty.")
            .Must(BeExistingUser).WithMessage("UserId does not exist in the database.")
            .Must(HaveNoCurrentBookings).WithMessage("User has upcoming or inprogress bookings.");

        RuleForEach(x => x.CarAccessoryIds)
        .Must((dto, accessoryId) => BeExistingCarAccessory(accessoryId)).WithMessage("One or more CarAccessoryIds do not exist in the database.");
    }

    private bool BeExistingCar(int carId)
    {
        return _rentalyDbContext.Cars.Any(x => x.Id == carId);
    }

    private bool BeExistingUser(int userId)
    {
        return _rentalyDbContext.Users.Any(x => x.Id == userId);
    }

    private bool BeExistingCarAccessory(int carAccessoryId)
    {
        return _rentalyDbContext.CarAccessories.Any(x => x.Id == carAccessoryId);
    }

    private bool HaveNoCurrentBookings(int userId)
    {
        return !_rentalyDbContext.Bookings.Any(x => x.UserId == userId && (x.Status == "upcoming" || x.Status == "inprogress"));
    }

    private bool IsCarAvailableInRange(int carId, DateOnly fromDate, DateOnly toDate)
    {
 
        bool isAvailable = !_rentalyDbContext.Bookings
            .Any(booking => booking.CarId == carId && !(toDate < booking.FromDate || fromDate > booking.ToDate) && booking.Status != BookingStatus.Canceled.ToString());

        return isAvailable;
    }
}
