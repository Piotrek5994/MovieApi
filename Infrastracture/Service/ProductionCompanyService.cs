using AutoMapper;
using Core.CommandDto;
using Core.Filter;
using Core.Model;
using Core.ModelDto;
using Infrastracture.Repositories;
using Infrastracture.Service.IService;

namespace Infrastracture.Service;

public class ProductionCompanyService : IProductionCompanyService
{
    private readonly IProductionCompanyRepositories _productionCompanyRepositories;
    private readonly IMapper _mapper;

    public ProductionCompanyService(IProductionCompanyRepositories productionCompanyRepositories, IMapper mapper)
    {
        _productionCompanyRepositories = productionCompanyRepositories;
        _mapper = mapper;
    }
    public async Task<List<Production_Company_Dto>> Get(ProductionCompanyFilter filter)
    {
        List<Production_Company> getProductionCompany = await _productionCompanyRepositories.Get(filter);
        List<Production_Company_Dto> mappedProductionCompany = _mapper.Map<List<Production_Company_Dto>>(getProductionCompany);
        return mappedProductionCompany;
    }
    public async Task<int> Post(Create_Production_Company_Dto productionCompany)
    {
        Production_Company mappedProductionCompany = _mapper.Map<Production_Company>(productionCompany);
        int createProductionCompanies = await _productionCompanyRepositories.CreateProductionCompany(mappedProductionCompany);
        return createProductionCompanies;
    }
    public async Task<bool> Put(Create_Production_Company_Dto productionCompany, int productionCompanyId)
    {
        Production_Company mappedProductionCompany = _mapper.Map<Production_Company>(productionCompany);
        bool changeProductionCompany = await _productionCompanyRepositories.UpdateProductionCompany(mappedProductionCompany, productionCompanyId);
        return changeProductionCompany;
    }
    public async Task<bool> Delete(int productionCompanyId)
    {
        bool deleteResult = await _productionCompanyRepositories.DeleteProductionCompany(productionCompanyId);
        return deleteResult;
    }

}
