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
    public async Task<ActionResult<bool>> Post([FromBody] Create_Movie_Company_Dto createMovieCompany)
    {
        bool createMovieCompanyResult = await _movieCompanyService.Post(createMovieCompany);
        if(!createMovieCompanyResult)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { Created = createMovieCompanyResult });
    }
    [HttpDelete]
    public async Task<ActionResult<bool>> Delete([FromQuery] int movieId, int companyId)
    {
        bool deleteResult = await _movieCompanyService.Delete(movieId,companyId);
        if(!deleteResult)
        {
            return BadRequest();
        }
        return Ok(deleteResult);
    }

}
