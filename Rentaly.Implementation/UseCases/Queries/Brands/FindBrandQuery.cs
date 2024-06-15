using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rentaly.Application.DTOs.Brands;
using Rentaly.Application.Exceptions;
using Rentaly.Application.UseCases.Queries.Brands;
using Rentaly.DataAccess;

namespace Rentaly.Implementation.UseCases.Queries.Brands;
public class FindBrandQuery : EfUseCase, IFindBrandQuery
{
    private readonly IMapper _mapper;
    public FindBrandQuery(RentalyDbContext context,IMapper mapper) : base(context)
    {
        _mapper = mapper;
    }

    public int Id => 24;

    public string Name => "Find brand by ID";

    public string Description => "Find brand by ID using EF";

    public BrandDto Execute(int request)
    {
        var brand = Context.Brands.Include(model => model.Models).FirstOrDefault(c => c.Id == request);


        if (brand is null)
            throw new EntityNotFoundException($"Entity with ID {request} not found.");

        var response = _mapper.Map<BrandDto>(brand);

        return response;
    }
}
