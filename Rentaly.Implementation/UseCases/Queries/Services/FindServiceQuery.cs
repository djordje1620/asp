using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rentaly.Application.DTOs.Services;
using Rentaly.Application.Exceptions;
using Rentaly.Application.UseCases.Queries.Services;
using Rentaly.DataAccess;

namespace Rentaly.Implementation.UseCases.Queries.Services;
public class FindServiceQuery : EfUseCase, IFindServiceQuery
{
    private readonly IMapper _mapper;
    public FindServiceQuery(RentalyDbContext context, IMapper mapper) : base(context)
    {
        _mapper = mapper;
    }

    public int Id => 33;

    public string Name => "Find service query";

    public string Description => "Find service query using Ef";

    public ServiceDto Execute(int request)
    {
        var service = Context.CarServices.Include(x => x.Car).ThenInclude(x => x.Model).FirstOrDefault(x => x.Id == request);

        if (service == null)
            throw new EntityNotFoundException($"Entity with ID {request} not found.");

        var response = new ServiceDto
        {
            Id = service.Id,
            ServiceName = service.ServiceName,
            Description = service.Description,
            FromDate = service.FromDate,
            ToDate = service.ToDate,
            Car = service.Car.Model.Name + " VIN number: " + service.Car.VIN,
            ServiceType = service.ServiceType.ToString(),
        };

        return response;
    }
}
