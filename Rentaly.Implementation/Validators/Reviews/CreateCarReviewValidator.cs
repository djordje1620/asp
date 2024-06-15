using FluentValidation;
using Rentaly.Application.DTOs;
using Rentaly.DataAccess;

namespace Rentaly.Implementation.Validators.Reviews;
public class CreateCarReviewValidator : AbstractValidator<CreateReviewDto>
{
    private readonly RentalyDbContext _rentalyDbContext;

    public CreateCarReviewValidator(RentalyDbContext rentalyDbContext)
    {
        _rentalyDbContext = rentalyDbContext;

        RuleFor(x => x.Comment)
            .NotEmpty().WithMessage("Comment must not be empty.");

        RuleFor(x => x.StarsRate)
            .InclusiveBetween(0, 5).WithMessage("StarsRate must be between 0 and 5.");

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId cannot be empty.")
            .Must(BeExistingUser).WithMessage("UserId does not exist in the database.");

        RuleFor(x => x.CarId)
            .NotEmpty().WithMessage("CarId cannot be empty.")
            .Must(BeExistingCar).WithMessage("CarId does not exist in the database.")
            .Must((dto, carId) => UserHasCompletedBookingWithCar(dto.UserId, carId))
                .WithMessage("No completed booking found for this user with the specified car.")
            .Must((dto, carId) => UserHasNoReviewForCar(dto.UserId, carId))
                .WithMessage("User already reviewed this car.");
    }

    private bool BeExistingUser(int userId)
    {
        return _rentalyDbContext.Users.Any(x => x.Id == userId);
    }

    private bool BeExistingCar(int carId)
    {
        return _rentalyDbContext.Cars.Any(x => x.Id == carId);
    }

    private bool UserHasCompletedBookingWithCar(int userId, int carId)
    {
        return _rentalyDbContext.Bookings.Any(x => x.UserId == userId && x.CarId == carId && x.Status == "completed");
    }

    private bool UserHasNoReviewForCar(int userId, int carId)
    {
        return !_rentalyDbContext.Reviews.Any(x => x.UserId == userId && x.CarId == carId);
    }
}

