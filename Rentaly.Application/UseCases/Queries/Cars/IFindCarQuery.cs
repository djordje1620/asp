using Rentaly.Application.DTOs.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentaly.Application.UseCases.Queries.Cars;
public interface IFindCarQuery : IQuery<int, CarDto>
{
}
