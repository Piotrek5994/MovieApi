using Core.CommandDto;
using Core.Filter;
using Core.ModelDto;
using Infrastracture.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace MovieApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService)
    {
        _personService = personService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Person_Dto>>> Get(PersonFilter filter)
    {
        List<Person_Dto> result = await _personService.Get(filter);
        if (result.Count <= 0)
        {
            return NotFound();
        }
        return Ok(result);
    }
    [HttpPost]
    public async Task<ActionResult<int>> Post(Create_Person_Dto createPerson)
    {
        int createdPersonId = await _personService.Post(createPerson);
        if (createdPersonId == 0)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = createdPersonId });
    }
    [HttpPut]
    public async Task<ActionResult<bool>> Put(Create_Person_Dto createPerson, int personId)
    {
        bool updateResult = await _personService.Put(createPerson, personId);
        if (!updateResult)
        {
            return BadRequest();
        }
        return Ok(updateResult);
    }
    [HttpDelete]
    public async Task<ActionResult<bool>> Put(int personId)
    {
        bool deleteResult = await _personService.Delete(personId);
        if(!deleteResult)
        {
            return BadRequest();
        }
        return Ok(deleteResult);
    }
}
