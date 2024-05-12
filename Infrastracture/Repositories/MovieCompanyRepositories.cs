using Core.Filter;
using Core.Model;
using Infrastracture.Db;
using Infrastracture.Helper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Infrastracture.Repositories;

public class MovieCompanyRepositories : IMovieCompanyRepositories
{
    private readonly MySqlDbContext _context;
    private readonly ILogger _log;

    public MovieCompanyRepositories(MySqlDbContext context, ILogger<MovieCompanyRepositories> log)
    {
        _context = context;
        _log = log;
    }
    public async Task<List<Movie_Company>> Get(MovieCompanyFilter filter)
    {
        try
        {

            IQueryable<Movie_Company> query = _context.movieCompanies.AsQueryable();

            //Filters
            if (filter.Movie_Id != null)
            {
                query = query.Where(x => x.Movie_id.Equals(filter.Movie_Id));
            }
            if(filter.Company_Id != null)
            {
                query = query.Where(x => x.Company_id.Equals(filter.Company_Id));
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
            _log.LogError(ex, $"Error get MovieCompany in MySql : Message - {ex.Message}");
            return new List<Movie_Company>();
        }
    }
    public async Task<int> CreateMovieCompany(Movie_Company movieCompany)
    {
        try
        {
            await _context.movieCompanies.AddAsync(movieCompany);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return 1;
        }
        catch (SqlException ex)
        {
            _log.LogError(ex, $"Error creating MovieCompany in MySql : Message - {ex.Message}");
            return 0;
        }

    }
    public async Task<bool> UpdateMovieCompany(Movie_Company movieCompany, int movieComapnyId)
    {
        try
        {
            Movie_Company? existingMovieCompany = await _context.movieCompanies.FindAsync(movieComapnyId);
            PropertyInfo[] properties = typeof(Movie_Company).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if(property.PropertyType == typeof(int))
                {
                    int newValue = (int)property.GetValue(movieCompany);
                    int existingValue = (int)property.GetValue(existingMovieCompany);
                    if (newValue != existingValue)
                    {
                        property.SetValue(existingMovieCompany, newValue);
                    }
                }
            }
            await _context.SaveChangesAsync();
            return true;
        }
        catch (SqlException ex)
        {
            _log.LogError(ex, $"Error updating MovieCompany in MySql : Message - {ex.Message}");
            return false;
        }
    }
    public async Task<bool> DeleteMovieCompany(int movieCompanyId)
    {
        try
        {
            Movie_Company? existingMovieCompany = await _context.movieCompanies.FindAsync(movieCompanyId);
            if (existingMovieCompany is null)
            {
                return false;
            }
            _context.movieCompanies.Remove(existingMovieCompany);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (SqlException ex)
        {
            _log.LogError(ex, $"Error delete MovieCompany in MySql : Message - {ex.Message}");
            return false;
        }
    }
}
