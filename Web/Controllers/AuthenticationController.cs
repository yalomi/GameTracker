using Application.Dtos;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("api/authentication")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public async Task<ActionResult> Register([FromBody] RegisterUserDto user)
    {
        var createdUser = await _authenticationService.Register(user);
        return Created();
    }
}