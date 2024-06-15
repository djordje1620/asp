using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rentaly.Application;
using Rentaly.Application.DTOs.Bookings;
using Rentaly.Application.DTOs.Search;
using Rentaly.Application.DTOs.Users;
using Rentaly.Application.UseCases.Queries;
using Rentaly.Application.UseCases.Queries.Users;
using Rentaly.DataAccess;
using Rentaly.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentaly.Implementation.UseCases.Queries.Users;
public class GetUsersQuery(RentalyDbContext context, IApplicationActor user, IMapper mapper) 
    : EfUseCase(context), IGetUsersQuery
{
    private readonly IApplicationActor _user = user;
    private readonly IMapper _mapper = mapper;
    public int Id => 50;

    public string Name => "Get all users query.";

    public string Description => "Get all users query using EF.";

    public PagedResponse<UserProfileDto> Execute(UserPagedSearchDto request)
    {
        IQueryable<User> query = Context.Users;

        if (!string.IsNullOrEmpty(request.Keyword))
        {
            query = query.Where(x => x.Email.Contains(request.Keyword) || x.UserName.Contains(request.Keyword));
        }


        if (request.PerPage == null || request.PerPage < 1)
        {
            request.PerPage = 15;
        }

        if (request.Page == null || request.Page < 1)
        {
            request.Page = 15;
        }

        var toSkip = (request.Page.Value - 1) * request.PerPage.Value;

        var response = new PagedResponse<UserProfileDto>();

        response.TotalCount = query.Count();

        response.Data = query.Skip(toSkip)
                             .Take(request.PerPage.Value)
                             .Select(query => _mapper.Map<UserProfileDto>(query));

        response.CurrentPage = request.Page.Value;

        response.ItemsPerPage = request.PerPage.Value;

        return response;
    }
}
