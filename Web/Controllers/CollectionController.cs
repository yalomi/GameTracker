using System.Security.Claims;
using Application.Dtos.GetDtos;
using Application.Dtos.PostDtos;
using Application.Dtos.PutDtos;
using Application.Interfaces.IManagers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Extensions;

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
        var userId = User.GetUserId() ?? throw new Exception();
        
        var userDtos = await _manager.CollectionService.GetAll(userId);
        return Ok(userDtos);
    }

    [Authorize]
    [HttpGet]
    [Route("{gameId}")]
    public async Task<ActionResult<GetGameDto>> GetUserGame(Guid gameId)
    {
        var userId = User.GetUserId() ?? throw new Exception();
        
        var game = await _manager.CollectionService.GetById(gameId, userId);
        return Ok(game);
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<GetGameDto>> AddGame([FromBody] PostGameDto gameDto)
    {
        var userId = User.GetUserId() ?? throw new Exception();

        var createdGame = await _manager.CollectionService.AddUserGame(gameDto, userId);
        return CreatedAtAction(nameof(GetUserGame), new { gameId = createdGame.Id }, createdGame);
    }

    [Authorize]
    [HttpPut("{gameId}")]
    public async Task<ActionResult<GetGameDto>> UpdateGame([FromBody] PutGameDto gameDto, [FromRoute] Guid gameId)
    {
        var userId = User.GetUserId() ?? throw new Exception();
        
        await _manager.CollectionService.UpdateUserGame(gameDto, gameId, userId);
        return NoContent();
    }
    
}