using Application.Dtos;
using Application.IServices;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IServiceManager _manager;

    public AuthController(IServiceManager manager)
    {
        _manager = manager;
    }

    [HttpPost("register")]
    public async Task<ActionResult> Register([FromBody] UserRegisterDto request)
    {
        await _manager.UserService.Register(request);
        return NoContent();
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] UserLoginDto request)
    {
        var token = await _manager.UserService.Login(request);

        return Ok();
    }
}