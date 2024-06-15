using AutoMapper;
using FluentValidation;
using Rentaly.Application.DTOs;
using Rentaly.Application.UseCases.Commands.Cars;
using Rentaly.DataAccess;
using Rentaly.Domain.Entities;
using Rentaly.Implementation.Validators.Reviews;

namespace Rentaly.Implementation.UseCases.Commands.Cars;
public class CreateCarReviewCommand(RentalyDbContext context, 
    CreateCarReviewValidator validator, IMapper mapper) 
    : EfUseCase(context), ICreateCarReviewCommand
{
    private readonly CreateCarReviewValidator _validator = validator;
    private readonly IMapper _mapper = mapper;

    public int Id => 14;

    public string Name => "Create review for booked car";

    public string Description => "Create review for booked car using Ef";

    public void Execute(CreateReviewDto request)
    {
        _validator.ValidateAndThrow(request);

        var review = _mapper.Map<Review>(request);

        Context.Reviews.Add(review);
        Context.SaveChanges();
    }
}
