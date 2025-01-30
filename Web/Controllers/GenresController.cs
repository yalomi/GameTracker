using Application.IServices;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("api/genres")]
public class GenresController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public GenresController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    [HttpGet]
    public async Task<ActionResult<List<Genre>>> GetAll()
    {
        var genres = await _serviceManager.GenreService.GetAll();
        return Ok(genres);
    }
    
    // [HttpPost("{id}")]
    // public async Task<IActionResult> CreateOne(int id)
    // {
    //     return Ok();
    // }
    //
    // [HttpPost("genres")]
    // public async Task<IActionResult> CreateMany()
    // {
    //     return Ok();
    // }
    
}