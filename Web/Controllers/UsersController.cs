using System.Security.Claims;
using Application.Dtos.PostDtos;
using Application.IServices;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("api")]
public class UsersController : ControllerBase
{
    private readonly IServiceManager _manager;
    
    public UsersController(IServiceManager manager)
    {
        _manager = manager;
    }
    [HttpGet("users")]
    public async Task<ActionResult<List<User>>> GetAll()
    {
        var userDtos = await _manager.UserService.GetAll();
        return Ok(userDtos);
    }

    [HttpPost("collection")]
    public async Task<ActionResult> AddGameToCollection([FromBody] AddGameToCollectionDto gameDto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (userId == null)
        {
            return Unauthorized();
        }

        await _manager.UserService.AddGameToCollection(gameDto, Guid.Parse(userId));
        return Created();
    }
}