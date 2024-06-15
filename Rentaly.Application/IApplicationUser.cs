using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentaly.Application;
public interface IApplicationActor
{
    int Id { get; }
    string Username { get; }
    string Email { get; }
    string FirstName { get; }
    string LastName { get; }
    string RoleName { get; }
    IEnumerable<int> AllowedUseCases { get; }
}
