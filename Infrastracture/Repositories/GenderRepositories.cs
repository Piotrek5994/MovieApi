using Core.Filter;
using Core.Model;
using Infrastracture.Db;
using Infrastracture.Helper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Infrastracture.Repositories;

public class GenderRepositories : IGenderRepositories
{
    private readonly MySqlDbContext _context;
    private readonly ILogger _log;

    public GenderRepositories(MySqlDbContext context, ILogger<GenderRepositories> log)
    {
        _context = context;
        _log = log;
    }
    public async Task<List<Gender>> Get(GenderFilter filter)
    {
        try
        {
            IQueryable<Gender> query = _context.genders.AsQueryable();

            //Filters
            if (filter.Id != null)
            {
                query = query.Where(x => x.Gender_id == filter.Id);
            }

            //Sort
            if (!string.IsNullOrEmpty(filter.SortBy))
            {
                query = SortHelper.ApplyDynamicSorting(query, filter.SortBy, filter.SortDirection);
            }

            //Pagination
            query = query.Skip((filter.Page - 1) * filter.Limit).Take(filter.Limit);

            var result = await query.ToListAsync().ConfigureAwait(false);
            return result;
        }
        catch (SqlException ex)
        {
            _log.LogError(ex, $"Error get gender in MySql : Message - {ex.Message}");
            return new List<Gender>();
        }
    }
    public async Task<int> CreateGender(Gender gender)
    {
        try
        {
            await _context.genders.AddAsync(gender);
            await _context.SaveChangesAsync();
            return gender.Gender_id;
        }
        catch(SqlException ex)
        {
            _log.LogError(ex, $"Error Post gender in MySql : Message - {ex.Message}");
            return 0;
        }
    }
    public async Task<bool>UpdateGender(Gender gender,int genderId)
    {
        try
        {
            Gender? existingGender = await _context.genders.FindAsync(genderId);
            PropertyInfo[] properties = typeof(Gender).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType == typeof(int))
                {
                    int newValue = (int)property.GetValue(gender);
                    int existingValue = (int)property.GetValue(existingGender);
                    if (newValue != existingValue)
                    {
                        property.SetValue(existingGender, newValue);
                    }
                }
                if (property.PropertyType == typeof(string))
                {
                    string newValue = (string)property.GetValue(gender);
                    string existingValue = (string)property.GetValue(existingGender);
                    if (!string.IsNullOrEmpty(newValue) && newValue != existingValue)
                    {
                        property.SetValue(existingGender, newValue);
                    }
                }
            }
            await _context.SaveChangesAsync();
            return true;
        }
        catch (SqlException ex)
        {
            _log.LogError(ex, $"Error put gender in MySql : Message - {ex.Message}");
            return false;
        }
    }
    public async Task<bool> DeleteGender(int genderId)
    {
        try
        {
            Gender? existingGender = await _context.genders.FindAsync(genderId);
            if (existingGender is null)
            {
                return false;
            }
            _context.genders.Remove(existingGender);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (SqlException ex)
        {
            _log.LogError(ex, $"Error delete movie in MySql : Message - {ex.Message}");
            return false;
        }
    }
}
