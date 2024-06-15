using FluentValidation;
using Rentaly.Application.DTOs.Bookings;
using Rentaly.DataAccess;
using Rentaly.Domain.Entities;

namespace Rentaly.Implementation.Validators.Bookings;
public class UpdateBookingValidator : AbstractValidator<UpdateBookingDto>
{
    private readonly RentalyDbContext _rentalyDbContext;

    public UpdateBookingValidator(RentalyDbContext rentalyDbContext)
    {
        _rentalyDbContext = rentalyDbContext;

        RuleFor(x => x.FromDate)
            .NotEmpty().WithMessage("FromDate cannot be empty.")
            .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today.AddDays(7))).WithMessage("FromDate must be at least 7 days from today's date.");

        RuleFor(x => x.ToDate)
            .NotEmpty().WithMessage("ToDate cannot be empty.")
            .GreaterThan(x => x.FromDate).WithMessage("ToDate must be greater than FromDate.");

        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Booking ID cannot be empty.")
            .Must(BeExistingBooking).WithMessage("Booking ID does not exist in the database.");

        RuleFor(x => x.FromDate)
            .Must((dto, fromDate) => IsBookingAvailable(dto.Id, fromDate, dto.ToDate)).WithMessage("Car is not available in the specified date range.");
    }

    private bool BeExistingBooking(int bookingId)
    {
        return _rentalyDbContext.Bookings.Any(x => x.Id == bookingId);
    }

    private bool IsBookingAvailable(int bookingId, DateOnly fromDate, DateOnly toDate)
    {
        var booking = _rentalyDbContext.Bookings.FirstOrDefault(x => x.Id == bookingId);

        if (booking == null)
            return false;

        bool isAvailable = !_rentalyDbContext.Bookings
            .Any(b => b.CarId == booking.CarId && b.Id != bookingId && !(toDate < b.FromDate || fromDate > b.ToDate) && b.Status != BookingStatus.Canceled.ToString());

        return isAvailable;
    }
}
