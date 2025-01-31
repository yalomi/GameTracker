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

    [HttpGet("{id}")]
    public async Task<ActionResult<Genre>> GetById(Guid id)
    {
        var genre = await _serviceManager.GenreService.GetById(id);
        return Ok(genre);
    }
    
    [HttpPost("{id}")]
    public async Task<IActionResult> CreateOne(int id)
    {
        await _serviceManager.GenreService.CreateOne(id);
        return Created();
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateMany()
    {
        await _serviceManager.GenreService.CreateMany();
        return Created();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteOne(Guid id)
    {
        await _serviceManager.GenreService.DeleteOne(id);
        return NoContent();
    }
    
}