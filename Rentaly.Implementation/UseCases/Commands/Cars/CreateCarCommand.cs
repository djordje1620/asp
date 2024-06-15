using AutoMapper;
using FluentValidation;
using Rentaly.Application.DTOs.Cars;
using Rentaly.Application.UseCases.Commands.Cars;
using Rentaly.DataAccess;
using Rentaly.Domain.Entities;
using Rentaly.Implementation.Validators.Cars;

namespace Rentaly.Implementation.UseCases.Commands.Cars;
public class CreateCarCommand : EfUseCase, ICreateCarCommand
{
    private readonly CreateCarValidator _validator;
    private readonly IMapper _mapper;
    public CreateCarCommand(RentalyDbContext context, CreateCarValidator validator, IMapper mapper): base(context)
    {
        _validator = validator;
        _mapper = mapper;
    }

    public int Id => 4;

    public string Name => "Create car command";

    public string Description => "Create car command using EF";

    public void Execute(CreateCarDto request)
    {
        _validator.ValidateAndThrow(request);

        var car = _mapper.Map<Car>(request);

        Context.Cars.Add(car);
        Context.SaveChanges();  
    }
}
