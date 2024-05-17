using Core.Filter;
using Core.Model;
using Infrastracture.Db;
using Infrastracture.Helper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Infrastracture.Repositories;

public class DepartmentRepositories : IDepartmentRepositories
{
    private readonly MySqlDbContext _context;
    private readonly ILogger _log;

    public DepartmentRepositories(MySqlDbContext context, ILogger<DepartmentRepositories> log)
    {
        _context = context;
        _log = log;
    }
    public async Task<List<Department>> Get(DepartmentFilter filter)
    {
        try
        {
            IQueryable<Department> query = _context.departments.AsQueryable();

            // Fliters
            if(filter.Id != null)
            {
                query = query.Where(x => x.Department_id == filter.Id);
            }

            // Sort
            if(!string.IsNullOrEmpty(filter.SortBy))
            {
                query = SortHelper.ApplyDynamicSorting(query, filter.SortBy, filter.SortDirection);
            }

            // Pagination
            query = query.Skip((filter.Page - 1) * filter.Limit).Take(filter.Limit);

            var result = await query.ToListAsync().ConfigureAwait(false);
            return result;
        }
        catch (SqlException ex)
        {
            _log.LogError(ex, $"Error get dpeartment in MySql : Message - {ex.Message}");
            return new List<Department>();
        }
    }
    public async Task<int> CreateDepartment(Department department)
    {
        try
        {
            await _context.departments.AddAsync(department);
            await _context.SaveChangesAsync();
            return department.Department_id;
        }
        catch(SqlException ex)
        {
            _log.LogError(ex, $"Error post department in MySql : Message - {ex.Message}");
            return 0;
        }
    }
    public async Task<bool> UpdateDepartment(Department department,int departemntId)
    {
        try
        {
            Department? existingDepartemnt = await _context.departments.FindAsync(departemntId);
            PropertyInfo[] properties = typeof(Department).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if(property.PropertyType == typeof(string))
                {
                    string newValue = (string)property.GetValue(department);
                    string existingValue = (string)property.GetValue(existingDepartemnt);
                    if(existingValue != newValue)
                    {
                        property.SetValue(existingValue, newValue);
                    }
                }
            }
            await _context.SaveChangesAsync();
            return true;
        }
        catch (SqlException ex)
        {
            _log.LogError(ex, $"Error update department in MySql : Message - {ex.Message}");
            return false;
        }
    }
    public async Task<bool> DeleteDepartment(int departmentId)
    {
        try
        {
            Department? existionDepartment = await _context.departments.FindAsync(departmentId);
            if(existionDepartment is null)
            {
                return false;
            }
            _context.departments.Remove(existionDepartment);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (SqlException ex)
        {
            _log.LogError(ex, $"Error delete department in MySql : Message - {ex.Message}");
            return false;
        }
    }
}
