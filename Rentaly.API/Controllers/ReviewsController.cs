using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rentaly.Application;
using Rentaly.Application.DTOs;
using Rentaly.Application.UseCases.Commands.Cars;
using Rentaly.Domain.Entities;
using Rentaly.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rentaly.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ReviewsController(UseCaseHandler useCaseHandler, IApplicationActor user) : ControllerBase
{
    private readonly UseCaseHandler _useCaseHandler = useCaseHandler;
    private readonly IApplicationActor _user = user; 

    /// <summary>
    /// Creates a new review.
    /// </summary>
    /// <param name="dto">Data for creating a review.</param>
    /// <param name="command">Command for creating a review.</param>
    /// <returns>Created review.</returns>
    /// <response code="201">Successful creation.</response>
    /// <response code="401">Unauthorized access.</response>
    /// <response code="403">Forbidden.</response>
    /// <response code="422">Data sent is invalid.</response>
    /// <response code="500">Internal server error.</response>
    [HttpPost]
    public IActionResult Post([FromBody] CreateReviewDto dto,
                     [FromServices] ICreateCarReviewCommand command)
    {
        dto.UserId = _user.Id;
        _useCaseHandler.HandleCommand(command, dto);
        return Ok(201);
    }
}
