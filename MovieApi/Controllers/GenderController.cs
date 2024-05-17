using Core.CommandDto;
using Core.Filter;
using Core.ModelDto;
using Infrastracture.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace MovieApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GenderController : ControllerBase
{
    private readonly IGenderService _genderService;

    public GenderController(IGenderService genderService)
    {
        _genderService = genderService;
    }
    [HttpGet]
    public async Task<ActionResult<List<Gender_Dto>>> Get(GenderFilter filter)
    {
        List<Gender_Dto> result = await _genderService.Get(filter);
        if (result.Count <= 0)
        {
            return NotFound();
        }
        return Ok(result);
    }
    [HttpPost]
    public async Task<ActionResult<int>> Post([FromBody] Create_Gender_Dto createGender)
    {
        int createGenderId = await _genderService.Post(createGender);
        if (createGenderId == 0)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = createGenderId });
    }
    [HttpPut]
    public async Task<ActionResult<bool>> Put([FromBody] Create_Gender_Dto updateGender, [FromQuery] int genderId)
    {
        bool updateResult = await _genderService.Put(updateGender, genderId);
        if (!updateResult)
        {
            return BadRequest();
        }
        return Ok(updateResult);
    }
    [HttpDelete]
    public async Task<ActionResult<bool>> Delete([FromQuery] int genderId)
    {
        bool deleteResult = await _genderService.Delete(genderId);
        if(!deleteResult)
        {
            return BadRequest();
        }
        return Ok(deleteResult);
    }
}
