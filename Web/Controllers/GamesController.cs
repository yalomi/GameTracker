using Application.IServices;
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

    [HttpPost("{id}")]
    public async Task<ActionResult> CreateOne(int id)
    {
        await _serviceManager.GameService.CreateOne(id);
        return Created();
    }
}