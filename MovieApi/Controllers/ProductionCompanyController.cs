using Core.CommandDto;
using Core.Filter;
using Core.ModelDto;
using Infrastracture.Service;
using Infrastracture.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace MovieApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductionCompanyController : ControllerBase
{
    private readonly IProductionCompanyService _productionCompanyService;

    public ProductionCompanyController(IProductionCompanyService productionCompanyService)
    {
        _productionCompanyService = productionCompanyService;
    }
    [HttpGet]
    public async Task<ActionResult<List<Production_Company_Dto>>> Get([FromQuery] ProductionCompanyFilter filter)
    {
        List<Production_Company_Dto> result = await _productionCompanyService.Get(filter);
        if (result.Count <= 0)
        {
            return NotFound();
        }
        return Ok(result);
    }
    [HttpPost]
    public async Task<ActionResult<int>> Post([FromBody] Create_Production_Company_Dto createProductionCompany)
    {
        int createProductionCompanyId = await _productionCompanyService.Post(createProductionCompany);
        if (createProductionCompanyId == 0)
        {
            return BadRequest("Unable to create user.");
        }
        return CreatedAtAction(nameof(Post), new { id = createProductionCompanyId });
    }
    [HttpPut]
    public async Task<ActionResult<bool>> Put([FromBody] Create_Production_Company_Dto updateProductionCompany, int productionCompanyId)
    {
        bool updateResult = await _productionCompanyService.Put(updateProductionCompany, productionCompanyId);
        if (!updateResult)
        {
            return BadRequest();
        }
        return Ok(updateResult);
    }
    [HttpDelete]
    public async Task<ActionResult<bool>> Delete([FromQuery] int productionCompanyId)
    {
        bool deleteResult = await _productionCompanyService.Delete(productionCompanyId);
        if (!deleteResult)
        {
            return BadRequest();
        }
        return Ok(deleteResult);
    }
}
