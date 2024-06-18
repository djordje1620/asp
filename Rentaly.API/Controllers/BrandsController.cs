using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rentaly.Application.DTOs.Brands;
using Rentaly.Application.DTOs.Search;
using Rentaly.Application.UseCases.Commands.Brands;
using Rentaly.Application.UseCases.Queries.Brands;
using Rentaly.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rentaly.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController(UseCaseHandler useCaseHandler) : ControllerBase
    {

        private readonly UseCaseHandler _useCaseHandler = useCaseHandler;

        /// <summary>
        /// Returns brands.
        /// </summary>
        /// <param name="search">Search parameters.</param>
        /// <param name="query">Query for retrieving brands.</param>
        /// <returns>List of brands.</returns>
        /// <response code="403">Forbidden.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery] CarPagedSearchDto search,
                                [FromServices] IGetBrandsQuery query)
        {
            return Ok(_useCaseHandler.HandleQuery(query, search));
        }

        /// <summary>
        /// Returns a brand based on ID.
        /// </summary>
        /// <param name="id">Brand ID.</param>
        /// <param name="query">Query for retrieving a brand.</param>
        /// <returns>Brand details.</returns>
        /// <response code="401">Unauthorized access.</response>
        /// <response code="403">Forbidden.</response>
        /// <response code="404">Brand with the given ID doesn't exist.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IFindBrandQuery query)
        {
            return Ok(_useCaseHandler.HandleQuery(query, id));
        }

        /// <summary>
        /// Creates a new brand.
        /// </summary>
        /// <param name="dto">Data for creating a brand.</param>
        /// <param name="command">Command for creating a brand.</param>
        /// <returns>Created brand.</returns>
        /// <response code="201">Successful creation.</response>
        /// <response code="401">Unauthorized access.</response>
        /// <response code="403">Forbidden.</response>
        /// <response code="422">Data sent is invalid.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPost]
        public IActionResult Post([FromBody] CreateBrandDto dto,
                         [FromServices] ICreateBrandCommand command)
        {
            _useCaseHandler.HandleCommand(command, dto);
            return StatusCode(201);
        }


        /// <summary>
        /// Deletes a brand with the given ID.
        /// </summary>
        /// <param name="id">Brand ID.</param>
        /// <param name="command">Command for deleting a brand.</param>
        /// <returns>No content.</returns>
        /// <response code="204">Successful deletion.</response>
        /// <response code="401">Unauthorized access.</response>
        /// <response code="403">Forbidden.</response>
        /// <response code="500">Internal server error.</response>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteBrandCommand command)
        {

            _useCaseHandler.HandleCommand(command, id);
            return StatusCode(204);
        }
    }
}
