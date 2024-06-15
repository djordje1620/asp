using Rentaly.Application.Exceptions;
using Rentaly.Application.UseCases.Commands.Cars;
using Rentaly.DataAccess;
using Rentaly.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentaly.Implementation.UseCases.Commands.Cars;
public class DeleteCarCommand : EfUseCase, IDeleteCarCommand
{
    public DeleteCarCommand(RentalyDbContext context) : base(context)
    {
    }

    public int Id => 7;

    public string Name => "Delete car command";

    public string Description => "Delete car command using EF";

    public void Execute(int request)
    {
        var car = Context.Cars.Find(request);

        if (car is null)
            throw new EntityNotFoundException($"Entity with ID {request} not found.");

        Context.Cars.Remove(car);
        Context.SaveChanges();
    }
}
