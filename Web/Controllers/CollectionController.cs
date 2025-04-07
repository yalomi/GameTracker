using System.Security.Claims;
using Application.Dtos.GetDtos;
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
    [HttpGet]
    [Route("{gameId}")]
    public async Task<ActionResult<GetGameDto>> GetUserGame(Guid gameId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null)
        {
            return Unauthorized();
        }
        
        var game = await _manager.CollectionService.GetById(gameId, Guid.Parse(userId));
        return Ok(game);
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<GetGameDto>> AddGame([FromBody] PostGameDto gameDto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
        {
            return Unauthorized();
        }

        var createdGame = await _manager.CollectionService.AddGameToCollection(gameDto, Guid.Parse(userId));
        return CreatedAtAction(nameof(GetUserGame), new { id = createdGame.Id }, createdGame);
    }
}