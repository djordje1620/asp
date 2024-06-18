using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rentaly.Application;
using Rentaly.Application.DTOs.Bookings;
using Rentaly.Application.DTOs.Search;
using Rentaly.Application.DTOs.Users;
using Rentaly.Application.UseCases.Commands.Users;
using Rentaly.Application.UseCases.Queries.Bookings;
using Rentaly.Application.UseCases.Queries.Users;
using Rentaly.Domain.Entities;
using Rentaly.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rentaly.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsersController(UseCaseHandler useCaseHandler) : ControllerBase
{
    private readonly UseCaseHandler _useCaseHandler = useCaseHandler;



    /// <summary>
    /// Retrieves profile information of all users.
    /// </summary>
    /// <param name="query">Query for retrieving profile information of all users.</param>
    /// <returns>List of profile information.</returns>
    /// <response code="204">Successful retrieval.</response>
    /// <response code="401">Unauthorized access.</response>
    /// <response code="403">Forbidden.</response>
    /// <response code="422">Data sent is invalid.</response>
    /// <response code="500">Internal server error.</response>
    [HttpGet]
    public IActionResult Get([FromServices] IGetUsersQuery query,[FromQuery] UserPagedSearchDto dto)
    {
        return Ok(_useCaseHandler.HandleQuery(query, dto));
    }


    /// <summary>
    /// Retrieves profile information for the current user.
    /// </summary>
    /// <param name="query">Query for retrieving profile information.</param>
    /// <returns>Profile information.</returns>
    /// <response code="204">Successful retrieval.</response>
    /// <response code="401">Unauthorized access.</response>
    /// <response code="403">Forbidden.</response>
    /// <response code="422">Data sent is invalid.</response>
    /// <response code="500">Internal server error.</response>
    [HttpGet("Profile")]
    public IActionResult GetProfileInfo([FromServices] IGetProfileInfoQuery query, IApplicationActor user)
    {
        var x = user;
        return Ok(_useCaseHandler.HandleQuery(query, new BaseSearch()));
    }

    /// <summary>
    /// Retrieves bookings for the current user.
    /// </summary>
    /// <param name="dto">Search criteria for retrieving bookings.</param>
    /// <param name="query">Query for retrieving user bookings.</param>
    /// <returns>User bookings.</returns>
    /// <response code="204">Successful retrieval.</response>
    /// <response code="401">Unauthorized access.</response>
    /// <response code="403">Forbidden.</response>
    /// <response code="422">Data sent is invalid.</response>
    /// <response code="500">Internal server error.</response>
    [HttpGet("MyBookings")]
    public IActionResult GetBookings([FromQuery] BookingPagedSearchDto dto, [FromServices] IGetUserBookingQuery query)
    {
        return Ok(_useCaseHandler.HandleQuery(query, dto));
    }

    /// <summary>
    /// Creates a new user.
    /// </summary>
    /// <param name="dto">Data for creating a user.</param>
    /// <param name="command">Command for creating a user.</param>
    /// <returns>Created user.</returns>
    /// <response code="201">Successful creation.</response>
    /// <response code="401">Unauthorized access.</response>
    /// <response code="403">Forbidden.</response>
    /// <response code="422">Data sent is invalid.</response>
    /// <response code="500">Internal server error.</response>
    [HttpPost]
    [AllowAnonymous]
    public IActionResult Post([FromBody] CreateUserDto dto, [FromServices] ICreateUserCommand command)
    {
        _useCaseHandler.HandleCommand(command, dto);
        return StatusCode(201);
    }

    /// <summary>
    /// Updates a user with the given ID.
    /// </summary>
    /// <param name="id">ID of the user.</param>
    /// <param name="dto">Data for updating the user.</param>
    /// <param name="command">Command for updating the user.</param>
    /// <returns>No content if successful.</returns>
    /// <response code="204">Successful update.</response>
    /// <response code="401">Unauthorized access.</response>
    /// <response code="403">Forbidden.</response>
    /// <response code="422">Data sent is invalid.</response>
    /// <response code="500">Internal server error.</response>
    [HttpPut("{id}")]
    public IActionResult Put(int id,
                             [FromBody] UpdateUserDto dto,
                             [FromServices] IUpdateUserCommand command)
    {
        dto.Id = id;
        _useCaseHandler.HandleCommand(command, dto);
        return StatusCode(204);
    }

    /// <summary>
    /// Deletes a user by ID.
    /// </summary>
    /// <param name="id">ID of the user to delete.</param>
    /// <param name="command">Command for deleting the user.</param>
    /// <returns>No content if successful.</returns>
    /// <response code="204">Successful deletion.</response>
    /// <response code="401">Unauthorized access.</response>
    /// <response code="403">Forbidden.</response>
    /// <response code="500">Internal server error.</response>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id, [FromServices] IDeleteUserCommand command)
    {

        _useCaseHandler.HandleCommand(command, id);
        return StatusCode(204);
    }
}
