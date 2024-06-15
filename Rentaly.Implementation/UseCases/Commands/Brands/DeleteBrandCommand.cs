using Rentaly.Application.Exceptions;
using Rentaly.Application.UseCases.Commands.Brands;
using Rentaly.DataAccess;
using Rentaly.Domain.Entities;

namespace Rentaly.Implementation.UseCases.Commands.Brands
{
    public class DeleteBrandCommand : EfUseCase, IDeleteBrandCommand
    {
        public DeleteBrandCommand(RentalyDbContext context) : base(context)
        {
        }

        public int Id => 4;

        public string Name => "Create brand command";

        public string Description => "Create brand command using EF";

        public void Execute(int request)
        {
            var brand = Context.Brands.Find(request);

            if (brand is null)
                throw new EntityNotFoundException($"Entity with ID {request} not found.");

            Context.Brands.Remove(brand);
            Context.SaveChanges();
        }
    }
}
