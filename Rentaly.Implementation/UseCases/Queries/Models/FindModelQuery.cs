using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rentaly.Application.DTOs.Models;
using Rentaly.Application.Exceptions;
using Rentaly.Application.UseCases.Queries.Models;
using Rentaly.DataAccess;

namespace Rentaly.Implementation.UseCases.Queries.Models;
public class FindModelQuery : EfUseCase, IFindModelQuery
{
    private readonly IMapper _mapper;
    public FindModelQuery(RentalyDbContext context,IMapper mapper) : base(context)
    {
        _mapper = mapper;
    }

    public int Id => 22;

    public string Name => "Find Model by ID.";

    public string Description => "Find model by ID using Ef";

    public ModelDto Execute(int request)
    {
        var modelEntity = Context.Models
                                   .Include(m => m.Brand)
                                   .Include(m => m.Cars)
                                   .FirstOrDefault(x => x.Id == request);

        if (modelEntity is null)
            throw new EntityNotFoundException($"Entity with ID {request} not found.");


        var response = _mapper.Map<ModelDto>(modelEntity);

        return response;
    }
}
