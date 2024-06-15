using AutoMapper;
using FluentValidation;
using Rentaly.Application.DTOs.Services;
using Rentaly.Application.UseCases.Commands.Services;
using Rentaly.DataAccess;
using Rentaly.Domain.Entities;
using Rentaly.Implementation.Validators.Services;

namespace Rentaly.Implementation.UseCases.Commands.Services;
public class CreateServiceCommand : EfUseCase, ICreateServiceCommand
{
    private readonly CreateServiceValidator _validator;
    private readonly IMapper _mapper;
    public CreateServiceCommand(RentalyDbContext context, CreateServiceValidator validator, IMapper mapper) : base(context)
    {
        _validator = validator;
        _mapper = mapper;
    }

    public int Id => 15;

    public string Name => "Create service command";

    public string Description => "Create service command using Ef";

    public void Execute(CreateServiceDto request)
    {
        _validator.ValidateAndThrow(request);

        var service = new CarService
        {
            ServiceName = request.ServiceName,
            Description = request.Description,
            CarId = request.CarId,
            FromDate = request.FromDate,
            ToDate = request.ToDate,
            ServiceType = request.ServiceType,
        };


        Context.CarServices.Add(service);
        Context.SaveChanges();
    }
}
