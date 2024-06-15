using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rentaly.Application.DTOs.Search;
using Rentaly.Application.UseCases.Queries;
using Rentaly.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rentaly.API.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AuditLogController(UseCaseHandler useCaseHandler) : ControllerBase
{
    private readonly UseCaseHandler _useCaseHandler = useCaseHandler;

    /// <summary>
    /// Returns audit log.
    /// </summary>
    /// <param name="search"></param>
    /// <param name="query"></param>
    /// <returns></returns>
    /// <response code="200">Ok.</response>
    /// <response code="403">Forbidden.</response>
    /// <response code="500">Internal server error.</response>
    [HttpGet]
    public IActionResult Get([FromQuery] AuditLogSearchDto search,
                              [FromServices] IGetAuditLogQuery query)
    {
        return Ok(_useCaseHandler.HandleQuery(query, search));
    }
}
