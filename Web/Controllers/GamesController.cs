using Application.Dtos;
using Application.IServices;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("api/games")]
public class GamesController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public GamesController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    [HttpGet]
    public async Task<ActionResult<List<GameDto>>> GetAll()
    {
        var gameDtos = await _serviceManager.GameService.GetAllAsync();
        return Ok(gameDtos);
    }

    [HttpPost("{id}")]
    public async Task<ActionResult> CreateOne(int id)
    {
        await _serviceManager.GameService.CreateOne(id);
        return Created();
    }

    [HttpPost]
    public async Task<ActionResult> CreateMany([FromQuery] int pageQuantity)
    {
        await _serviceManager.GameService.CreateMany(pageQuantity);
        return Created();
    }
}