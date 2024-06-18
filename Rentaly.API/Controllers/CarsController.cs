using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rentaly.API.DTOs;
using Rentaly.Application.DTOs.Cars;
using Rentaly.Application.UseCases.Commands.Cars;
using Rentaly.Application.UseCases.Queries.Cars;
using Rentaly.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rentaly.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CarsController(UseCaseHandler useCaseHandler) : ControllerBase
{
    private readonly UseCaseHandler _useCaseHandler = useCaseHandler;

    /// <summary>
    /// Returns cars.
    /// </summary>
    /// <param name="search">Search parameters.</param>
    /// <param name="query">Query for retrieving cars.</param>
    /// <returns>List of cars.</returns>
    /// <response code="403">Forbidden.</response>
    /// <response code="500">Internal server error.</response>
    [HttpGet]
    public IActionResult Get([FromQuery] Application.DTOs.Search.CarPagedSearchDto search,
                           [FromServices] IGetCarsQuery query)
    {
        return Ok(_useCaseHandler.HandleQuery(query, search));
    }

    /// <summary>
    /// Returns a car based on ID.
    /// </summary>
    /// <param name="id">Car ID.</param>
    /// <param name="query">Query for retrieving a car.</param>
    /// <returns>Car details.</returns>
    /// <response code="401">Unauthorized access.</response>
    /// <response code="403">Forbidden.</response>
    /// <response code="404">Car with the given ID doesn't exist.</response>
    /// <response code="500">Internal server error.</response>
    [HttpGet("{id}")]
    [AllowAnonymous]
    public IActionResult Get(int id, [FromServices] IFindCarQuery query)
    {
        return Ok(_useCaseHandler.HandleQuery(query, id));
    }

    /// <summary>
    /// Creates a new car.
    /// </summary>
    /// <param name="dto">Data for creating a car.</param>
    /// <param name="command">Command for creating a car.</param>
    /// <returns>Created car.</returns>
    /// <response code="201">Successful creation.</response>
    /// <response code="401">Unauthorized access.</response>
    /// <response code="403">Forbidden.</response>
    /// <response code="422">Data sent is invalid.</response>
    /// <response code="500">Internal server error.</response>
    [HttpPost]
    public IActionResult Post([FromForm] CreateCarWithImageDto dto,
                     [FromServices] ICreateCarCommand command)
    {

        var guid = Guid.NewGuid();
        var extension = Path.GetExtension(dto.Image.FileName);

        if(!SupprtedExtensions.Contains(extension))
        {
            throw new InvalidOperationException("Invalid operation exception");
        }

        var newFileName = guid + extension;

        var path = Path.Combine("wwwroot", "images", newFileName);

        using(var fileStream = new FileStream(path, FileMode.Create))
        {
            dto.Image.CopyTo(fileStream);
        }

        dto.ImagePath = path;
        _useCaseHandler.HandleCommand(command, dto);
        return Ok(201);
    }

    private IEnumerable<string> SupprtedExtensions => new List<string> { ".png", ".jpg", ".jpeg" };

    /// <summary>
    /// Updates a car with the given ID.
    /// </summary>
    /// <param name="id">Car ID.</param>
    /// <param name="dto">Data for updating a car.</param>
    /// <param name="command">Command for updating a car.</param>
    /// <returns>No content.</returns>
    /// <response code="204">Successful update.</response>
    /// <response code="401">Unauthorized access.</response>
    /// <response code="403">Forbidden.</response>
    /// <response code="422">Data sent is invalid.</response>
    /// <response code="500">Internal server error.</response>
    [HttpPatch("{id}/Price")]
    public IActionResult ChangePricePerDay(int id,
                             [FromBody] UpdateCarDto dto,
                             [FromServices] IUpdateCarCommand command)
    {
        dto.Id = id;
        _useCaseHandler.HandleCommand(command, dto);
        return StatusCode(204);
    }

    /// <summary>
    /// Deletes a car with the given ID.
    /// </summary>
    /// <param name="id">Car ID.</param>
    /// <param name="command">Command for deleting a car.</param>
    /// <returns>No content.</returns>
    /// <response code="204">Successful deletion.</response>
    /// <response code="401">Unauthorized access.</response>
    /// <response code="403">Forbidden.</response>
    /// <response code="500">Internal server error.</response>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id, [FromServices] IDeleteCarCommand command)
    {

        _useCaseHandler.HandleCommand(command, id);
        return StatusCode(204);
    }
}
