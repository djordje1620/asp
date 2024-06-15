using AutoMapper;
using FluentValidation;
using Rentaly.Application.DTOs.Brands;
using Rentaly.Application.UseCases.Commands.Brands;
using Rentaly.DataAccess;
using Rentaly.Domain.Entities;
using Rentaly.Implementation.Validators.Brands;

namespace Rentaly.Implementation.UseCases.Commands.Brands
{
    public class CreateBrandCommand : EfUseCase, ICreateBrandCommand
    {
        private readonly CreateBrandValidator _validator;
        private readonly IMapper _mapper;
        public CreateBrandCommand(RentalyDbContext context, CreateBrandValidator validator, IMapper mapper) : base(context)
        {
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 3;

        public string Name => "Create brand command";

        public string Description => "Create brand command using ef";

        public void Execute(CreateBrandDto request)
        {
            _validator.ValidateAndThrow(request);

            var brand = _mapper.Map<Brand>(request);

            Context.Brands.Add(brand);
            Context.SaveChanges();
        }
    }
}
