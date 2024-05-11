using Core.CommandDto;
using Core.Filter;
using Core.ModelDto;
using Infrastracture.Service.IService;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MovieApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Movie_User_Dto>>> Get([FromQuery] UserFilter filter)
    {
        List<Movie_User_Dto> result = await _userService.Get(filter);
        if (result.Count <= 0)
        {
            return NotFound();
        }
        return Ok(result);
    }
    [HttpPost]
    public async Task<ActionResult<int>> Post([FromBody] Create_Movie_User_Dto createUser)
    {
        int createUserId = await _userService.Post(createUser);
        if (createUserId == 0)
        {
            return BadRequest("Unable to create user.");
        }
        return CreatedAtAction(nameof(Post), new { id = createUserId });

    }
    [HttpPut]
    public async Task<ActionResult<bool>> Put([FromBody] Create_Movie_User_Dto updateUser, [FromQuery] int userId)
    {
        bool updateResult = await _userService.Put(updateUser, userId);
        if (!updateResult)
        {
            return BadRequest();
        }
        return Ok(updateResult);
    }
    [HttpDelete]
    public async Task<ActionResult<bool>> Delete([FromQuery] int userId)
    {
        bool deleteResult = await _userService.Delete(userId);
        if(!deleteResult)
        {
            return BadRequest();
        }
        return Ok(deleteResult);
    }
}
