using Core.Filter;
using Core.Model;
using Infrastracture.Db;
using Infrastracture.Helper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastracture.Repositories;

public class UserRepositories : IUserRepositories
{
    private readonly MySqlDbContext _context;
    private readonly ILogger _log;

    public UserRepositories(MySqlDbContext context, ILogger<UserRepositories> log)
    {
        _context = context;
        _log = log;
    }
    public async Task<List<Movie_User>> Get(UserFilter filter)
    {
        try
        {

            IQueryable<Movie_User> query = _context.users.AsQueryable();

            //Filters
            if (filter.Id != null)
            {
                query = query.Where(x => x.User_id.Equals(filter.Id));
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
            _log.LogError(ex, $"Error get user in MySql : Message - {ex.Message}");
            return new List<Movie_User>();
        }
    }
    public async Task<int> CreateUser(Movie_User user)
    {
        try
        {
            await _context.users.AddAsync(user);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return user.User_id;
        }
        catch (SqlException ex)
        {
            _log.LogError(ex, $"Error creating user in MySql : Message - {ex.Message}");
            return 0;
        }

    }
    public async Task<bool> UpdateUser(Movie_User user,int userId)
    {
        try
        {
            Movie_User? existingUser = await _context.users.FindAsync(userId);
            var properties = typeof(Movie_User).GetProperties();
            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(string))
                {
                    string newValue = (string)property.GetValue(user);
                    if (!string.IsNullOrEmpty(newValue))
                    {
                        property.SetValue(existingUser, newValue);
                    }
                }
            }
            await _context.SaveChangesAsync();
            return true;
        }
        catch (SqlException ex)
        {
            _log.LogError(ex, $"Error updating user in MySql : Message - {ex.Message}");
            return false;
        }
    }
    public async Task<bool> DeleteUser(int userId)
    {
        try
        {
            Movie_User? existingUser = await _context.users.FindAsync(userId);
            if (existingUser is null)
            {
                return false;
            }
            _context.users.Remove(existingUser);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (SqlException ex)
        {
            _log.LogError(ex, $"Error delete user in MySql : Message - {ex.Message}");
            return false;
        }
    }
}
