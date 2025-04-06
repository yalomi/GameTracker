using System.Security.Claims;
using Application.Dtos.PostDtos;
using Application.Interfaces.IManagers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("/api/collection")]
public class CollectionController : ControllerBase
{
    private readonly IServiceManager _manager;
    public CollectionController(IServiceManager manager)
    {
        _manager = manager;
    }
    
    [Authorize]
    [HttpGet]
    public async Task<ActionResult> GetCollection()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null)
        {
            return Unauthorized();
        }
        
        var userDtos = await _manager.CollectionService.GetAll(Guid.Parse(userId));
        return Ok(userDtos);
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult> AddGame([FromBody] PostGameDto gameDto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
        {
            return Unauthorized();
        }

        await _manager.CollectionService.AddGameToCollection(gameDto, Guid.Parse(userId));
        return Created();
    }
}