using Core.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GamesController : ControllerBase
{
    // private readonly GamesRepository _repository;
    //
    // public GamesController(GamesRepository repository)
    // {
    //     _repository = repository;
    // }
    // [HttpGet]   
    // public ActionResult<List<Game>> Get()
    // {
    //     return Ok(_repository.GetAll());
    // }
    //
    // [HttpPost("{id}")]
    // public async Task<ActionResult> AddNewGame(int id)
    // {
    //     await _repository.FetchGameToDb(id);
    //     return Created();
    // }
}