using Rentaly.Application.UseCases.Commands.Bookings;
using Rentaly.Application.UseCases.Commands.Brands;
using Rentaly.Application.UseCases.Commands.Cars;
using Rentaly.Application.UseCases.Commands.Models;
using Rentaly.Application.UseCases.Commands.Services;
using Rentaly.Application.UseCases.Commands.Users;
using Rentaly.Application.UseCases.Commands;
using Rentaly.Implementation.UseCases.Commands.Bookings;
using Rentaly.Implementation.UseCases.Commands.Brands;
using Rentaly.Implementation.UseCases.Commands.Cars;
using Rentaly.Implementation.UseCases.Commands.Models;
using Rentaly.Implementation.UseCases.Commands.Services;
using Rentaly.Implementation.UseCases.Commands.Users;
using Rentaly.Implementation.UseCases.Commands;
using Rentaly.Application.UseCases.Queries.Bookings;
using Rentaly.Application.UseCases.Queries.Brands;
using Rentaly.Application.UseCases.Queries.Cars;
using Rentaly.Application.UseCases.Queries.Models;
using Rentaly.Application.UseCases.Queries.Services;
using Rentaly.Application.UseCases.Queries.Users;
using Rentaly.Application.UseCases.Queries;
using Rentaly.Implementation.UseCases.Queries.Bookings;
using Rentaly.Implementation.UseCases.Queries.Brands;
using Rentaly.Implementation.UseCases.Queries.Cars;
using Rentaly.Implementation.UseCases.Queries.Models;
using Rentaly.Implementation.UseCases.Queries.Services;
using Rentaly.Implementation.UseCases.Queries.Users;
using Rentaly.Implementation.UseCases.Queries;
using Rentaly.Implementation.Validators.Brands;
using Rentaly.Implementation.Validators.Cars;
using Rentaly.Implementation.Validators.Models;
using Rentaly.Implementation.Validators.Services;
using Rentaly.Implementation.Validators.Users;
using Rentaly.Application.Logging;
using Rentaly.Implementation.Logging;
using Rentaly.Implementation.Validators.Bookings;
using Rentaly.Implementation.Validators.Reviews;
using Rentaly.API.Core;
using Rentaly.DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Newtonsoft.Json;
using Rentaly.Domain.Entities;
using Rentaly.Application.UseCases.Logging;
using Rentaly.Implementation.UseCases.Logging;
using System.IdentityModel.Tokens.Jwt;

namespace Rentaly.API.Extensions;

public static class Extensions
{
    public static IServiceCollection AddCommands(this IServiceCollection services)
    {
        services.AddTransient<ICreateInitialDataCommand, CreateInitialDataCommand>();
        services.AddTransient<ICreateModelCommand, CreateModelCommand>(); 
        services.AddTransient<IDeleteModelCommand, DeleteModelCommand>();
        services.AddTransient<ICreateBrandCommand, CreateBrandCommand>(); 
        services.AddTransient<IDeleteBrandCommand, DeleteBrandCommand>();
        services.AddTransient<ICreateCarCommand, CreateCarCommand>(); 
        services.AddTransient<IUpdateCarCommand, UpdateCarCommand>(); 
        services.AddTransient<IDeleteCarCommand, DeleteCarCommand>();
        services.AddTransient<IDeleteBookingCommand, DeleteBookingCommand>();
        services.AddTransient<IUpdateBookingCommand, UpdateBookingCommand>();
        services.AddTransient<ICreateBookingCommand, CreateBookingCommand>(); 
        services.AddTransient<IStartBookingCommand, StartBookingCommand>();
        services.AddTransient<IConfirmBookingCommand, CompleteBookingCommand>();
        services.AddTransient<ICancelBookingCommand, CancelBookingCommand>();
        services.AddTransient<ICreateCarReviewCommand, CreateCarReviewCommand>(); 
        services.AddTransient<ICreateServiceCommand, CreateServiceCommand>(); 
        services.AddTransient<IDeleteUserCommand, DeleteUserCommand>();
        services.AddTransient<IUpdateUserCommand, UpdateUserCommand>(); 
        services.AddTransient<IDeleteServiceCommand, DeleteServiceCommand>();
        services.AddTransient<ICreateUserCommand, CreateUserCommand>();
        services.AddTransient<IUpdateBookingCommand, UpdateBookingCommand>();

        return services;
    }

    public static IServiceCollection AddQueries(this IServiceCollection services)
    {
        services.AddTransient<IGetModelsQuery, GetModelsQuery>();
        services.AddTransient<IFindModelQuery, FindModelQuery>();
        services.AddTransient<IGetBrandsQuery, GetBrandsQuery>();
        services.AddTransient<IFindBrandQuery, FindBrandQuery>();
        services.AddTransient<IGetCarsQuery, GetCarsQuery>();
        services.AddTransient<IFindCarQuery, FindCarQuery>();
        services.AddTransient<IGetBookingsQuery, GetBookingsQuery>();
        services.AddTransient<IFindBookingQuery, FindBookingQuery>();
        services.AddTransient<IGetAuditLogQuery, GetAuditLogQuery>();
        services.AddTransient<IGetProfileInfoQuery, GetProfileInfoQuery>();
        services.AddTransient<IGetServicesQuery, GetServicesQuery>();
        services.AddTransient<IFindServiceQuery, FindServiceQuery>();
        services.AddTransient<IGetUserBookingQuery, GetUserBookingQuery>();
        services.AddTransient<IGetUsersQuery, GetUsersQuery>();

        return services;
    }

    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddTransient<CreateModelValidator>();
        services.AddTransient<CreateBrandValidator>();
        services.AddTransient<CreateCarValidator>();
        services.AddTransient<CreateBookingValidator>();
        services.AddTransient<CreateCarReviewValidator>();
        services.AddTransient<CreateServiceValidator>();
        services.AddTransient<UpdateUserValidator>();
        services.AddTransient<CreateUserValidator>();
        services.AddTransient<CompleteBookingValidator>();
        services.AddTransient<UpdateCarValidator>();
        services.AddTransient<UpdateBookingValidator>();

        return services;
    }

    public static IServiceCollection AddLoggers(this IServiceCollection services)
    {

        services.AddTransient<IExceptionLogger, ConsoleExceptionLogger>();
        services.AddTransient<IUseCaseLogger, DatabaseUseCaseLogger>();

        return services;
    }

    public static Guid? GetTokenId(this HttpRequest request)
    {
        if (request == null || !request.Headers.ContainsKey("Authorization"))
        {
            return null;
        }

        string authHeader = request.Headers["Authorization"].ToString();

        if (authHeader.Split("Bearer ").Length != 2)
        {
            return null;
        }

        string token = authHeader.Split("Bearer ")[1];

        var handler = new JwtSecurityTokenHandler();

        var tokenObj = handler.ReadJwtToken(token);

        var claims = tokenObj.Claims;

        var claim = claims.First(x => x.Type == "jti").Value;

        var tokenGuid = Guid.Parse(claim);

        return tokenGuid;
    }
}
