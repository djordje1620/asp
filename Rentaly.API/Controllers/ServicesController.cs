using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rentaly.Application.DTOs.Search;
using Rentaly.Application.DTOs.Services;
using Rentaly.Application.UseCases.Commands.Services;
using Rentaly.Application.UseCases.Queries.Services;
using Rentaly.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rentaly.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ServicesController(UseCaseHandler useCaseHandler) : ControllerBase
{
    private readonly UseCaseHandler _useCaseHandler = useCaseHandler;

    /// <summary>
    /// Retrieves a list of services.
    /// </summary>
    /// <param name="search">Search criteria.</param>
    /// <param name="query">Query for retrieving services.</param>
    /// <returns>List of services.</returns>
    /// <response code="403">Forbidden.</response>
    /// <response code="500">Internal server error.</response>
    [HttpGet]
    public IActionResult Get([FromQuery] ServicePagedSearchDto search,
                            [FromServices] IGetServicesQuery query)
    {
        return Ok(_useCaseHandler.HandleQuery(query, search));
    }

    /// <summary>
    /// Retrieves a service by ID.
    /// </summary>
    /// <param name="id">ID of the service.</param>
    /// <param name="query">Query for retrieving service by ID.</param>
    /// <returns>Service with the specified ID.</returns>
    /// <response code="401">Unauthorized access.</response>
    /// <response code="403">Forbidden.</response>
    /// <response code="404">Service with the given ID doesn't exist.</response>
    /// <response code="500">Internal server error.</response>
    [HttpGet("{id}")]
    public IActionResult Get(int id, [FromServices] IFindServiceQuery query)
    {
        return Ok(_useCaseHandler.HandleQuery(query, id));
    }

    /// <summary>
    /// Creates a new service.
    /// </summary>
    /// <param name="dto">Data for creating a service.</param>
    /// <param name="command">Command for creating a service.</param>
    /// <returns>Created service.</returns>
    /// <response code="201">Successful creation.</response>
    /// <response code="401">Unauthorized access.</response>
    /// <response code="403">Forbidden.</response>
    /// <response code="422">Data sent is invalid.</response>
    /// <response code="500">Internal server error.</response>
    [HttpPost]
    public IActionResult Post([FromBody] CreateServiceDto dto,
                     [FromServices] ICreateServiceCommand command)
    {
        _useCaseHandler.HandleCommand(command, dto);
        return Ok(201);
    }

    /// <summary>
    /// Deletes a service by ID.
    /// </summary>
    /// <param name="id">ID of the service to delete.</param>
    /// <param name="command">Command for deleting the service.</param>
    /// <returns>No content if successful.</returns>
    /// <response code="204">Successful deletion.</response>
    /// <response code="401">Unauthorized access.</response>
    /// <response code="403">Forbidden.</response>
    /// <response code="500">Internal server error.</response>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id, [FromServices] IDeleteServiceCommand command)
    {

        _useCaseHandler.HandleCommand(command, id);
        return StatusCode(204);
    }
}
