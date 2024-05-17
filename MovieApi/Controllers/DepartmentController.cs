using Core.CommandDto;
using Core.Filter;
using Core.ModelDto;
using Infrastracture.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace MovieApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentService _departmentService;
    public DepartmentController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Department_Dto>>> Get([FromQuery] DepartmentFilter filter)
    {
        List<Department_Dto> result = await _departmentService.Get(filter);
        if(result.Count <= 0)
        {
            return NotFound();
        }
        return Ok(result);
    }
    [HttpPost]
    public async Task<ActionResult<int>> Post([FromBody] Create_Department_Dto createDepartment)
    {
        int createDepartmentId = await _departmentService.Post(createDepartment);
        if(createDepartmentId == 0)
        {
            return BadRequest("Unable to create department.");
        }
        return CreatedAtAction(nameof(Post), new { id = createDepartmentId });
    }
    [HttpPut]
    public async Task<ActionResult<bool>> Put([FromBody] Create_Department_Dto updateDepartment, [FromQuery] int departmentId)
    {
        bool updateResult = await _departmentService.Put(updateDepartment, departmentId);
        if(!updateResult)
        {
            return BadRequest();
        }
        return Ok(updateResult);
    }
    [HttpDelete]
    public async Task<ActionResult<bool>> Delete([FromQuery] int departmentId)
    {
        bool deleteResult = await _departmentService.Delete(departmentId);
        if(!deleteResult)
        {
            return BadRequest();
        }
        return Ok(deleteResult);
    }
}
