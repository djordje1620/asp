using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rentaly.API.Core;
using Rentaly.API.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rentaly.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{

   private readonly JwtTokenCreator _tokenCreator;

    public AuthController(JwtTokenCreator tokenCreator)
    {
        _tokenCreator = tokenCreator;
    }

    /// <summary>
    /// Generates and returns a token from correct user credentials.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <response code="200">Successfull authentication.</response>
    /// <response code="403">Incorrect credentials.</response>
    /// <response code="500">Internal server error.</response>
    [HttpPost]
    [AllowAnonymous]
    public IActionResult Post([FromBody] AuthDto request)
    {
        string token = _tokenCreator.Create(request.Email, request.Password);

        return Ok(new AuthResponse { Token = token });
    }

    /// <summary>
    /// Delete token.
    /// </summary>
    /// <returns></returns>
    /// <response code="204">Successfull authentication.</response>
    [Authorize]
    [HttpDelete]
    public IActionResult Delete([FromServices] ITokenStorage storage)
    {
        storage.Remove(this.Request.GetTokenId().Value);

        return NoContent();
    }
}

public class AuthDto
{
    public string Email { get; set; }
    public string Password { get; set; }

}

public class AuthResponse
{
    public string Token { get; set; }
}