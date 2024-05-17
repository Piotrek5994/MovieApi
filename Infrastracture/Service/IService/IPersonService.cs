using Core.CommandDto;
using Core.Filter;
using Core.ModelDto;

namespace Infrastracture.Service.IService;

public interface IPersonService
{
    Task<List<Person_Dto>> Get(PersonFilter filter);
    Task<int> Post(Create_Person_Dto createPerson);
    Task<bool> Put(Create_Person_Dto createPerson, int personId);
    Task<bool> Delete(int personId);
}
