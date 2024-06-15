using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rentaly.Application.DTOs.Models;
using Rentaly.Application.DTOs.Search;
using Rentaly.Application.UseCases.Commands.Models;
using Rentaly.Application.UseCases.Queries.Models;
using Rentaly.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rentaly.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ModelsController(UseCaseHandler useCaseHandler) : ControllerBase
    {
       
        private readonly UseCaseHandler _useCaseHandler = useCaseHandler;

        /// <summary>
        /// Returns models.
        /// </summary>
        /// <param name="search">Search parameters.</param>
        /// <param name="query">Query for retrieving models.</param>
        /// <returns>List of models.</returns>
        /// <response code="403">Forbidden.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery] ModelPagedSearch search,
                               [FromServices] IGetModelsQuery query)
        {
            return Ok(_useCaseHandler.HandleQuery(query, search));
        }

        /// <summary>
        /// Returns a model based on ID.
        /// </summary>
        /// <param name="id">Model ID.</param>
        /// <param name="query">Query for retrieving a model.</param>
        /// <returns>Model details.</returns>
        /// <response code="401">Unauthorized access.</response>
        /// <response code="403">Forbidden.</response>
        /// <response code="404">Model with the given ID doesn't exist.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IFindModelQuery query)
        {
            return Ok(_useCaseHandler.HandleQuery(query, id));
        }

        /// <summary>
        /// Creates a new model.
        /// </summary>
        /// <param name="dto">Data for creating a model.</param>
        /// <param name="command">Command for creating a model.</param>
        /// <returns>Created model.</returns>
        /// <response code="201">Successful creation.</response>
        /// <response code="401">Unauthorized access.</response>
        /// <response code="403">Forbidden.</response>
        /// <response code="422">Data sent is invalid.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPost]
        public IActionResult Post([FromBody] CreateModelDto dto,
                         [FromServices] ICreateModelCommand command)
        {
            _useCaseHandler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        /// <summary>
        /// Deletes a model with the given ID.
        /// </summary>
        /// <param name="id">Model ID.</param>
        /// <param name="command">Command for deleting a model.</param>
        /// <returns>No content.</returns>
        /// <response code="204">Successful deletion.</response>
        /// <response code="401">Unauthorized access.</response>
        /// <response code="403">Forbidden.</response>
        /// <response code="500">Internal server error.</response>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteModelCommand command)
        {
            
            _useCaseHandler.HandleCommand(command, id);
            return StatusCode(204);
        }
    }
}
