using AutoMapper;
using Rentaly.Application;
using Rentaly.Application.DTOs.Search;
using Rentaly.Application.DTOs.Users;
using Rentaly.Application.UseCases.Queries.Users;
using Rentaly.DataAccess;
using Rentaly.Domain.Entities;

namespace Rentaly.Implementation.UseCases.Queries.Users;
public class GetProfileInfoQuery(RentalyDbContext context, IApplicationActor user, IMapper mapper) 
    : EfUseCase(context), IGetProfileInfoQuery
{
    private readonly IMapper _mapper = mapper;
    private readonly IApplicationActor _user = user;
    public int Id => 30;

    public string Name => "Get profile info of logged in user";

    public string Description => "Get profile info of logged in user using Ef";

    public UserProfileDto Execute(BaseSearch request)
    {
        var query = Context.Users.Find(_user.Id);
        
        return _mapper.Map<UserProfileDto>(query);  
    }
}
