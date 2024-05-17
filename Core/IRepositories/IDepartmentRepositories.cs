using Core.Filter;
using Core.Model;

namespace Infrastracture.Repositories;

public interface IDepartmentRepositories
{
    Task<List<Department>> Get(DepartmentFilter filter);
    Task<int> CreateDepartment(Department department);
    Task<bool> UpdateDepartment(Department department, int departmentId);
    Task<bool> DeleteDepartment(int  departmentId);
}
