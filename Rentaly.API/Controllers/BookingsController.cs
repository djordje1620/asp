using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rentaly.Application;
using Rentaly.Application.DTOs.Bookings;
using Rentaly.Application.DTOs.Search;
using Rentaly.Application.UseCases.Commands.Bookings;
using Rentaly.Application.UseCases.Queries.Bookings;
using Rentaly.Domain.Entities;
using Rentaly.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rentaly.API.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BookingsController(UseCaseHandler useCaseHandler, IApplicationActor user) : ControllerBase
{
    private readonly IApplicationActor _user = user;
    private readonly UseCaseHandler _useCaseHandler = useCaseHandler;

    /// <summary>
    /// Returns bookings.
    /// </summary>
    /// <param name="search">Search parameters.</param>
    /// <param name="query">Query for retrieving bookings.</param>
    /// <returns>List of bookings.</returns>
    /// <response code="403">Forbidden.</response>
    /// <response code="500">Internal server error.</response>
    [HttpGet]
    public IActionResult Get([FromQuery] BookingPagedSearchDto search,
                            [FromServices] IGetBookingsQuery query)
    {
        return Ok(_useCaseHandler.HandleQuery(query, search));
    }

    /// <summary>
    /// Returns a booking based on ID.
    /// </summary>
    /// <param name="id">Booking ID.</param>
    /// <param name="query">Query for retrieving a booking.</param>
    /// <returns>Booking details.</returns>
    /// <response code="401">Unauthorized access.</response>
    /// <response code="403">Forbidden.</response>
    /// <response code="404">Booking with the given ID doesn't exist.</response>
    /// <response code="500">Internal server error.</response>
    [HttpGet("{id}")]
    public IActionResult Get(int id, [FromServices] IFindBookingQuery query)
    {
        return Ok(_useCaseHandler.HandleQuery(query, id));
    }


    /// <summary>
    /// Creates a new booking.
    /// </summary>
    /// <param name="dto">Data for creating a booking.</param>
    /// <param name="command">Command for creating a booking.</param>
    /// <returns>Created booking.</returns>
    /// <response code="201">Successful creation.</response>
    /// <response code="401">Unauthorized access.</response>
    /// <response code="403">Forbidden.</response>
    /// <response code="422">Data sent is invalid.</response>
    /// <response code="500">Internal server error.</response>
    [HttpPost]
    public IActionResult Post([FromBody] CreateBookingDto dto,
                     [FromServices] ICreateBookingCommand command)
    {
        dto.UserId = _user.Id;
        _useCaseHandler.HandleCommand(command, dto);
        return Ok(201);
    }

    /// <summary>
    /// Updates a booking with the given ID.
    /// </summary>
    /// <param name="id">Booking ID.</param>
    /// <param name="dto">Data for updating a booking.</param>
    /// <param name="command">Command for updating a booking.</param>
    /// <returns>No content.</returns>
    /// <response code="204">Successful update.</response>
    /// <response code="401">Unauthorized access.</response>
    /// <response code="403">Forbidden.</response>
    /// <response code="422">Data sent is invalid.</response>
    /// <response code="500">Internal server error.</response>
    [HttpPut("{id}")]
    public IActionResult Put(int id,
                             [FromBody] UpdateBookingDto dto,
                             [FromServices] IUpdateBookingCommand command)
    {
        //dto.Id = id;
        _useCaseHandler.HandleCommand(command, dto);
        return StatusCode(204);
    }

    /// <summary>
    /// Cancels a booking with the given ID.
    /// </summary>
    /// <param name="id">Booking ID.</param>
    /// <param name="command">Command for canceling a booking.</param>
    /// <returns>No content.</returns>
    /// <response code="204">Successful cancellation.</response>
    /// <response code="401">Unauthorized access.</response>
    /// <response code="403">Forbidden.</response>
    /// <response code="422">Data sent is invalid.</response>
    /// <response code="500">Internal server error.</response>
    [HttpPatch("{id}/Cancel")]
    public IActionResult CancelBooking(int id, [FromServices] ICancelBookingCommand command)
    {
        _useCaseHandler.HandleCommand(command, id);
        return StatusCode(204);
    }

    /// <summary>
    /// Confirms a booking with the given ID.
    /// </summary>
    /// <param name="id">Booking ID.</param>
    /// <param name="command">Command for confirming a booking.</param>
    /// <returns>No content.</returns>
    /// <response code="204">Successful confirmation.</response>
    /// <response code="401">Unauthorized access.</response>
    /// <response code="403">Forbidden.</response>
    /// <response code="422">Data sent is invalid.</response>
    /// <response code="500">Internal server error.</response>
    [HttpPatch("{id}/Confirm")]
    public IActionResult ConfirmBooking(int id,[FromBody] CompleteBookingDto dto, [FromServices] IConfirmBookingCommand command)
    {
        dto.Id = id;
        _useCaseHandler.HandleCommand(command, dto);
        return StatusCode(204);
    }

    /// <summary>
    /// Starts a booking with the given ID.
    /// </summary>
    /// <param name="id">Booking ID.</param>
    /// <param name="command">Command for starting a booking.</param>
    /// <returns>No content.</returns>
    /// <response code="204">Successful start.</response>
    /// <response code="401">Unauthorized access.</response>
    /// <response code="403">Forbidden.</response>
    /// <response code="422">Data sent is invalid.</response>
    /// <response code="500">Internal server error.</response>
    [HttpPatch("{id}/Start")]
    public IActionResult StartBooking(int id, [FromServices] IStartBookingCommand command)
    {
        _useCaseHandler.HandleCommand(command, id);
        return StatusCode(204);
    }


    /// <summary>
    /// Deletes a booking with the given ID.
    /// </summary>
    /// <param name="id">Booking ID.</param>
    /// <param name="command">Command for deleting a booking.</param>
    /// <returns>No content.</returns>
    /// <response code="204">Successful deletion.</response>
    /// <response code="401">Unauthorized access.</response>
    /// <response code="403">Forbidden.</response>
    /// <response code="500">Internal server error.</response>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id, [FromServices] IDeleteBookingCommand command)
    {

        _useCaseHandler.HandleCommand(command, id);
        return StatusCode(204);
    }
}
