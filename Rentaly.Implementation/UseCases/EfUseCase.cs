using Rentaly.DataAccess;

namespace Rentaly.Implementation.UseCases
{
    public abstract class EfUseCase
    {
        protected EfUseCase(RentalyDbContext context)
        {
            Context = context;
        }

        protected RentalyDbContext Context { get; }
    }
}
