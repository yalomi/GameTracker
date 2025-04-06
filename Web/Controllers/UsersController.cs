using Application.Interfaces.IManagers;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IServiceManager _manager;
    public UsersController(IServiceManager manager)
    {
        _manager = manager;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<User>>> GetAll()
    {
        var userDtos = await _manager.UserService.GetAll();
        return Ok(userDtos);
    }
}