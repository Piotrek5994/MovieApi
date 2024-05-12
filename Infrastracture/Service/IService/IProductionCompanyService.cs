using Core.CommandDto;
using Core.Filter;
using Core.ModelDto;

namespace Infrastracture.Service.IService;

public interface IProductionCompanyService
{
    Task<List<Production_Company_Dto>> Get(ProductionCompanyFilter filter);
    Task<int> Post(Create_Production_Company_Dto productionCompany);
    Task<bool> Put(Create_Production_Company_Dto productionCompany, int productionCompanyId);
    Task<bool> Delete(int productionCompanyId);
}
