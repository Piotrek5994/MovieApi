using Core.CommandDto;
using Core.Filter;
using Core.ModelDto;
using Infrastracture.Service;
using Infrastracture.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace MovieApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MovieCrewController : ControllerBase
{
    private readonly IMovieCrewService _movieCrewService;

    public MovieCrewController(IMovieCrewService movieCrewService)
    {
        _movieCrewService = movieCrewService;
    }
    [HttpGet]
    public async Task<ActionResult<List<Movie_Crew_Dto>>> Get([FromQuery] MovieCrewFilter filter)
    {
        List<Movie_Crew_Dto> result = await _movieCrewService.Get(filter);
        if (result.Count <= 0)
        {
            return NotFound();
        }
        return Ok(result);
    }
    [HttpPost]
    public async Task<ActionResult<bool>> Post([FromBody] Create_Movie_Crew_Dto createMovieCrew)
    {
        bool createMovieCrewResult = await _movieCrewService.Post(createMovieCrew);
        if (!createMovieCrewResult)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { Created = createMovieCrewResult });
    }
    [HttpDelete]
    public async Task<ActionResult<bool>> Delete([FromQuery] int movieId, int personId, int departmentId)
    {
        bool deleteResult = await _movieCrewService.Delete(movieId, personId,departmentId);
        if (!deleteResult)
        {
            return BadRequest();
        }
        return Ok(deleteResult);
    }
}
