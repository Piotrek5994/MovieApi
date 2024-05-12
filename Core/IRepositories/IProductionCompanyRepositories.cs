using Core.Filter;
using Core.Model;

namespace Infrastracture.Repositories;

public interface IProductionCompanyRepositories
{
    Task<List<Production_Company>> Get(ProductionCompanyFilter filter);
    Task<int> CreateProductionCompany(Production_Company productionCompany);
    Task<bool> UpdateProductionCompany(Production_Company productionCompany, int productionCompanyId);
    Task<bool> DeleteProductionCompany(int productionCompanyId);
}
