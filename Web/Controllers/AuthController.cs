using Application.Dtos;
using Application.Interfaces.IManagers;
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
    public async Task<ActionResult<TokenResponseDto>> Login([FromBody] UserLoginDto request)
    {
        var response = await _manager.UserService.Login(request);

        return Ok(response);
    }

    [HttpPost("refresh-token")]
    public async Task<ActionResult<TokenResponseDto>> RefreshToken(RefreshTokenRequestDto request)
    {
        var result = await _manager.UserService.RefreshTokensAsync(request);
        return Ok(result);
    }
    
}