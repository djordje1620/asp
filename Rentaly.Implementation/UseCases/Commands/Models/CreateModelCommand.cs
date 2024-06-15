using AutoMapper;
using FluentValidation;
using Rentaly.Application.DTOs.Models;
using Rentaly.Application.UseCases.Commands.Models;
using Rentaly.DataAccess;
using Rentaly.Domain.Entities;
using Rentaly.Implementation.Validators.Models;

namespace Rentaly.Implementation.UseCases.Commands.Models
{
    public class CreateModelCommand : EfUseCase,ICreateModelCommand
    {
        private readonly CreateModelValidator _validator;
        private readonly IMapper _mapper;
        public CreateModelCommand(RentalyDbContext context, CreateModelValidator validator, IMapper mapper) : base(context)
        {
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 1;

        public string Name => "Create model Command.";

        public string Description => "Inserts model into the database using Entity Framework.";

        public void Execute(CreateModelDto request)
        {

            _validator.ValidateAndThrow(request);

            var model = _mapper.Map<Model>(request);

            Context.Add(model);

            Context.SaveChanges();
        }
    }
}
