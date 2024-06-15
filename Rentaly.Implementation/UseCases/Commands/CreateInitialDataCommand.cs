using Rentaly.Application.DTOs;
using Rentaly.Application.UseCases.Commands;
using Rentaly.DataAccess;

namespace Rentaly.Implementation.UseCases.Commands
{
    public class CreateInitialDataCommand : EfUseCase, ICreateInitialDataCommand
    {
        public CreateInitialDataCommand(RentalyDbContext context) : base(context)
        {
        }

        public int Id => 20;

        public string Name => "Create initial data Command.";

        public string Description => "Inserts initial data into the database using Entity Framework.";

        public void Execute(InitialDataDTO request)
        {
            Context.AddRange(request.Brands);
            Context.AddRange(request.Specifications);
            Context.AddRange(request.CarTypes);
            Context.AddRange(request.Roles);
            Context.AddRange(request.Accessories);

            Context.SaveChanges();
        }
    }
}
