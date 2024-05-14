using Core.CommandDto;
using Core.Filter;
using Core.ModelDto;
using Infrastracture.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace MovieApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MovieCastController : ControllerBase
{
    private readonly IMovieCastService _movieCastService;

    public MovieCastController(IMovieCastService movieCastService)
    {
        _movieCastService = movieCastService;
    }
    [HttpGet]
    public async Task<ActionResult<List<Movie_Cast_Dto>>> Get([FromQuery] MovieCastFilter filter)
    {
        List<Movie_Cast_Dto> result = await _movieCastService.Get(filter);
        if (result.Count <= 0)
        {
            return NotFound();
        }
        return Ok(result);
    }
    [HttpPost]
    public async Task<ActionResult<bool>> Post([FromBody] Create_Movie_Cast_Dto movieCastDto)
    {
        bool createMovieCastResult = await _movieCastService.Post(movieCastDto);
        if (!createMovieCastResult)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { Created = createMovieCastResult });
    }
    [HttpDelete]
    public async Task<ActionResult<bool>> Delete([FromQuery] int movieId, int personId, int genderId)
    {
        bool deleteResult = await _movieCastService.Delete(movieId, personId, genderId);
        if(!deleteResult)
        {
            return BadRequest();
        }
        return Ok(deleteResult);
    }
}
