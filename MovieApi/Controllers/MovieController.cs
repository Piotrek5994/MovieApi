using Core.Filter;
using Core.Model;
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
    public async Task<ActionResult<List<Movie>>> Get([FromQuery] MovieFilter filter)
    {
        
    }
}
