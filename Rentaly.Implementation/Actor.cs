using Rentaly.Application;
using Rentaly.Application.Constant;

namespace Rentaly.Implementation;
public class Actor : IApplicationActor
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string RoleName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public IEnumerable<int> AllowedUseCases { get; set; }
}

public class UnauthorizedActor : IApplicationActor
{
    public int Id => 0;
    public string Username => "unauthorized";
    public string Email => "/";
    public string FirstName => "unauthorized";
    public string LastName => "unauthorized";
    public string RoleName => "unauthorized";
    public IEnumerable<int> AllowedUseCases => Constants.AnonimousUserUseCaseIds;
}
