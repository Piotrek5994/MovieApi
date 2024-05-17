using Core.CommandDto;
using Core.Filter;
using Core.Model;
using Core.ModelDto;
using Infrastracture.Service;
using Infrastracture.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace MovieApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MovieController : ControllerBase
{
    private readonly IMovieService _movieService;

    public MovieController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Movie_Dto>>> Get([FromQuery] MovieFilter filter)
    {
        List<Movie_Dto> result = await _movieService.Get(filter);
        if (result.Count <= 0)
        {
            return NotFound();
        }
        return Ok(result);
    }
    [HttpPost]
    public async Task<ActionResult<int>> Post([FromBody] Create_Movie_Dto createMovie)
    {
        int createMovieId = await _movieService.Post(createMovie);
        if(createMovieId == 0)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = createMovieId });
    }
    [HttpPut]
    public async Task<ActionResult<bool>> Put([FromBody] Create_Movie_Dto updateMovie,[FromQuery]int movieId)
    {
        bool updateResult = await _movieService.Put(updateMovie, movieId);
        if (!updateResult)
        {
            return BadRequest();
        }
        return Ok(updateResult);
    }
    [HttpDelete]
    public async Task<ActionResult<bool>> Delete([FromQuery] int movieId)
    {
        bool deleteResult = await _movieService.Delete(movieId);
        if (!deleteResult)
        {
            return BadRequest();
        }
        return Ok(deleteResult);
    }
}
