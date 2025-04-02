using Application.Dtos;
using Application.IServices;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("api/genres")]
public class GenresController : ControllerBase
{
    private readonly IServiceManager _manager;

    public GenresController(IServiceManager manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public async Task<ActionResult<List<Genre>>> GetAll()
    {
        var genres = await _manager.GenreService.GetAll();
        return Ok(genres);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetGenreDto>> GetById([FromRoute]Guid id)
    {
        var genre = await _manager.GenreService.GetById(id);
        return Ok(genre);
    }
    
    [HttpPost("{id}")]
    public async Task<IActionResult> CreateOne(int id)
    {
        await _manager.GenreService.CreateOne(id);
        return Created();
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateMany()
    {
        await _manager.GenreService.CreateMany();
        return Created();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteOne(Guid id)
    {
        await _manager.GenreService.DeleteOne(id);
        return NoContent();
    }
    
}