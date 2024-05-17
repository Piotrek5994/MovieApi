using Core.CommandDto;
using Core.Filter;
using Core.ModelDto;

namespace Infrastracture.Service.IService;

public interface IDepartmentService
{
    Task<List<Department_Dto>> Get(DepartmentFilter filter);
    Task<int> Post(Create_Department_Dto departmentDto);
    Task<bool> Put(Create_Department_Dto departmentDto, int departmentId);
    Task<bool> Delete(int  departmentId);
}
