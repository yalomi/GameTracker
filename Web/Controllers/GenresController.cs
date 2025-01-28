using Application;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenresController : ControllerBase
{
    private readonly GenreService _genreService;

    public GenresController(GenreService genreService)
    {
        _genreService = genreService;
    }
    
    [HttpPost("{id}")]
    public async Task<IActionResult> Create(int id)
    {
        await _genreService.CreateGenre(id);
        return Created();
    }
}