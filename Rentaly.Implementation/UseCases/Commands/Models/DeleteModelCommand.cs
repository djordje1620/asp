using Rentaly.Application.Exceptions;
using Rentaly.Application.UseCases.Commands.Models;
using Rentaly.DataAccess;
using Rentaly.Domain.Entities;

namespace Rentaly.Implementation.UseCases.Commands.Models
{
    public class DeleteModelCommand : EfUseCase, IDeleteModelCommand
    {
        public DeleteModelCommand(RentalyDbContext context) : base(context)
        {
        }

        public int Id => 2;

        public string Name => "Delete model Command.";

        public string Description => "Delete model into the database using Entity Framework.";

        public void Execute(int request)
        {
            var model = Context.Models.Find(request);

            if (model is null)
                throw new EntityNotFoundException($"Entity with ID {request} not found.");

            Context.Remove(model);

            Context.SaveChanges();
        }
    }
}
