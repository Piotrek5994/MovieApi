using AutoMapper;
using Core.CommandDto;
using Core.Filter;
using Core.Model;
using Core.ModelDto;
using Infrastracture.Repositories;
using Infrastracture.Service.IService;

namespace Infrastracture.Service;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepositories _departmentRepositories;
    private readonly IMapper _mapper;

    public DepartmentService(IDepartmentRepositories departmentRepositories, IMapper mapper)
    {
        _departmentRepositories = departmentRepositories;
        _mapper = mapper;
    }
    public async Task<List<Department_Dto>> Get(DepartmentFilter filter)
    {
        List<Department> getDepartmentList = await _departmentRepositories.Get(filter);
        List<Department_Dto> mappedDepartment = _mapper.Map<List<Department_Dto>>(getDepartmentList);
        return mappedDepartment;
    }
    public async Task<int> Post(Create_Department_Dto departmentDto)
    {
        Department mapperDepartment = _mapper.Map<Department>(departmentDto);
        int createDepartmentDto = await _departmentRepositories.CreateDepartment(mapperDepartment);
        return createDepartmentDto;
    }
    public async Task<bool> Put(Create_Department_Dto departmentDto,int departmentId)
    {
        Department mappedDepartment = _mapper.Map<Department>(departmentDto);
        bool changeDepartment = await _departmentRepositories.UpdateDepartment(mappedDepartment, departmentId);
        return changeDepartment;
    }
    public async Task<bool> Delete(int departmentId)
    {
        bool deleteResult = await _departmentRepositories.DeleteDepartment(departmentId);
        return deleteResult;
    }
}
