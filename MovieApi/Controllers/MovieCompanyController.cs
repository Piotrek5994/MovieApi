using Core.CommandDto;
using Core.Filter;
using Core.ModelDto;
using Infrastracture.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace MovieApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MovieCompanyController : ControllerBase
{
    private readonly IMovieCompanyService _movieCompanyService;

    public MovieCompanyController(IMovieCompanyService movieCompanyService)
    {
        _movieCompanyService = movieCompanyService;
    }
    [HttpGet]
    public async Task<ActionResult<List<Movie_Company_Dto>>> Get([FromQuery] MovieCompanyFilter filter)
    {
        List<Movie_Company_Dto> result = await _movieCompanyService.Get(filter);
        if(result.Count <= 0)
        {
            return NotFound();
        }
        return Ok(result);
    }
    [HttpPost]
    public async Task<ActionResult<int>> Post([FromBody] Create_Movie_Company_Dto createMovieCompany)
    {
        int createMovieCompanyId = await _movieCompanyService.Post(createMovieCompany);
        if(createMovieCompanyId == 0)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = createMovieCompanyId });
    }
    [HttpPut]
    public async Task<ActionResult<bool>> Put([FromBody] Create_Movie_Company_Dto createMovieCompany, int movieCompanyId)
    {
        bool updateResult = await _movieCompanyService.Put(createMovieCompany, movieCompanyId);
        if(!updateResult)
        {
            return BadRequest();
        }
        return Ok(updateResult);
    }
    [HttpDelete]
    public async Task<ActionResult<bool>> Delete([FromQuery] int movieCompanyId)
    {
        bool deleteResult = await _movieCompanyService.Delete(movieCompanyId);
        if(!deleteResult)
        {
            return BadRequest();
        }
        return Ok(deleteResult);
    }

}
