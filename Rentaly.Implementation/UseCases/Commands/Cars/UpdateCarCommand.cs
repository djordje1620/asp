using FluentValidation;
using Rentaly.Application.DTOs.Cars;
using Rentaly.Application.Exceptions;
using Rentaly.Application.UseCases.Commands.Cars;
using Rentaly.DataAccess;
using Rentaly.Domain.Entities;
using Rentaly.Implementation.Validators.Cars;

namespace Rentaly.Implementation.UseCases.Commands.Cars;
public class UpdateCarCommand : EfUseCase, IUpdateCarCommand
{
    private readonly UpdateCarValidator _validator;
    public UpdateCarCommand(RentalyDbContext context, UpdateCarValidator validator) : base(context)
    {
        _validator = validator;
    }

    public int Id => 5;

    public string Name => "Update car command";

    public string Description => "Update car command using Ef";

    public void Execute(UpdateCarDto request)
    {
        _validator.ValidateAndThrow(request);

        var price = Context.Prices.FirstOrDefault(x => x.CarId == request.Id && x.DeletedAt == null);

        if (price is null)
            throw new EntityNotFoundException($"Entity with ID {request} not found.");

        price.DeletedAt = DateTime.UtcNow;

        var newPrice = new Price
        {
            CarId = price.CarId,
            PricePerDay = request.PricePerDay
        };

        Context.Prices.Add(newPrice);
        Context.SaveChanges();

    }
}
