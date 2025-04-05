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
    public async Task<ActionResult<string>> Login([FromBody] UserLoginDto request)
    {
        var token = await _manager.UserService.Login(request);
        
        Response.Cookies.Append("jwt", token, new CookieOptions
        {
            HttpOnly = true, 
            Secure = true,  
            SameSite = SameSiteMode.Strict, 
            Expires = DateTimeOffset.UtcNow.AddMinutes(5) 
        });

        return Ok(token);
    }
}