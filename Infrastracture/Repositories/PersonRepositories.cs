using Core.Filter;
using Core.Model;
using Infrastracture.Db;
using Infrastracture.Helper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Infrastracture.Repositories;

public class PersonRepositories : IPersonRepositories
{
    private readonly MySqlDbContext _context;
    private readonly ILogger _log;

    public PersonRepositories(MySqlDbContext context, ILogger<PersonRepositories> log)
    {
        _context = context;
        _log = log;
    }
    public async Task<List<Person>> Get(PersonFilter filter)
    {
        try
        {
            IQueryable<Person> query = _context.persons.AsQueryable();

            //Filters
            if(filter.Id != null)
            {
                query = query.Where(x => x.Person_id == filter.Id);
            }

            //Sort
            if(!string.IsNullOrEmpty(filter.SortBy))
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
            _log.LogError(ex, $"Error get person in MySql : Message - {ex.Message}");
            return new List<Person>();
        }
    }
    public async Task<int> CreatePerson(Person person)
    {
        try
        {
            await _context.persons.AddAsync(person);
            await _context.SaveChangesAsync();
            return person.Person_id;
        }
        catch(SqlException ex)
        {
            _log.LogError(ex, $"Error post person in MySql : Message - {ex.Message}");
            return 0;
        }
    }
    public async Task<bool> UpdatePerson(Person person,int personId)
    {
        try
        {
            Person? existingPerson = await _context.persons.FindAsync(personId);
            PropertyInfo[] properties = typeof(Person).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if(property.PropertyType == typeof(string))
                {
                    string newValue = (string)property.GetValue(person);
                    string existingValue = (string)property.GetValue(existingPerson);
                    if (existingValue != newValue)
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
            _log.LogError(ex, $"Error update person in MySql : Message - {ex.Message}");
            return false;
        }
    }
    public async Task<bool> DeletePerson(int personId)
    {
        try
        {
            Person? existionPerson = await _context.persons.FindAsync(personId);
            if(existionPerson is null)
            {
                return false;
            }
            _context.persons.Remove(existionPerson);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (SqlException ex)
        {
            _log.LogError(ex, $"Error delete person in MySql : Message - {ex.Message}");
            return false;
        }
    }
}
