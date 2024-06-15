using FluentValidation;
using Rentaly.Application.DTOs.Bookings;
using Rentaly.DataAccess;

namespace Rentaly.Implementation.Validators.Bookings;
public class CompleteBookingValidator : AbstractValidator<CompleteBookingDto>
{
    private readonly RentalyDbContext _rentalyDbContext;

    public CompleteBookingValidator(RentalyDbContext rentalyDbContext)
    {
        _rentalyDbContext = rentalyDbContext;

        RuleFor(dto => dto.Id).NotEmpty().WithMessage("Id is required.");
        RuleFor(dto => dto.Kilometars).NotEmpty().WithMessage("Kilometars is required.").GreaterThan(0).WithMessage("Kilometars must be greater than 0.");
        RuleFor(dto => dto.Id)
            .Must(BookingExists).WithMessage("Booking does not exist.")
            .When(dto => dto.Id > 0);

        RuleFor(dto => dto)
            .Must(dto => MileageIsValidForBooking(dto.Id, dto.Kilometars)).WithMessage("New mileage is lower than the current mileage of the car in the booking.");
    }

    private bool BookingExists(int bookingId)
    {
        return _rentalyDbContext.Bookings.Any(b => b.Id == bookingId);
    }

    private bool MileageIsValidForBooking(int bookingId, float newKilometars)
    {
        var booking = _rentalyDbContext.Bookings.FirstOrDefault(b => b.Id == bookingId);
        var car = _rentalyDbContext.Cars.Find(booking.CarId);

        return newKilometars >= car.Kilometars;
    
    }
}
