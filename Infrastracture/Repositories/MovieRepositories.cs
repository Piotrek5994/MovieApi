using Core.Filter;
using Core.IRepositories;
using Core.Model;
using Infrastracture.Db;
using Infrastracture.Helper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Infrastracture.Repositories;

public class MovieRepositories : IMovieRepositories
{
    private readonly MySqlDbContext _context;
    private readonly ILogger _log;

    public MovieRepositories(MySqlDbContext context, ILogger<MovieRepositories> logger)
    {
        _context = context;
        _log = logger;
    }
    public async Task<List<Movie>> Get(MovieFilter filter)
    {
        try
        {
            IQueryable<Movie> query = _context.movies.AsQueryable();

            //Filters
            if(filter.Id != null)
            {
                query = query.Where(x => x.Movie_id == filter.Id);
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
            _log.LogError(ex, $"Error get movie in MySql : Message - {ex.Message}");
            return new List<Movie>();
        }
    }
    public async Task<int> CreateMovie(Movie movie)
    {
        try
        {
            await _context.movies.AddAsync(movie);
            await _context.SaveChangesAsync();
            return movie.Movie_id;
        }
        catch(SqlException ex)
        {
            _log.LogError(ex, $"Error post movie in MySql : Message - {ex.Message}");
            return 0;
        }
    }
    public async Task<bool> UpdateMovie(Movie movie, int movieId)
    {
        try
        {
            Movie? existingMovie = await _context.movies.FindAsync(movie);
            PropertyInfo [] properties = typeof(Movie).GetProperties();
            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(int))
                {
                    int newValue = (int)property.GetValue(movie);
                    int existingValue = (int)property.GetValue(existingMovie);
                    if (newValue != existingValue)
                    {
                        property.SetValue(existingMovie, newValue);
                    }
                }
                if(property.PropertyType == typeof(decimal))
                {
                    decimal newValue = (decimal)property.GetValue(movie);
                    decimal existingValue = (decimal)property.GetValue(existingMovie);
                    if(newValue != existingValue)
                    {
                        property.SetValue(existingMovie, newValue);
                    }
                }
                if (property.PropertyType == typeof(string))
                {
                    string newValue = (string)property.GetValue(movie);
                    string existingValue = (string)property.GetValue(existingMovie);
                    if (!string.IsNullOrEmpty(newValue) && newValue != existingValue)
                    {
                        property.SetValue(existingMovie, newValue);
                    }
                }
            }
            await _context.SaveChangesAsync();
            return true;
        }
        catch (SqlException ex)
        {
            _log.LogError(ex, $"Error put movie in MySql : Message - {ex.Message}");
            return false;
        }
    }
    public async Task<bool> DeleteMovie(int movieId)
    {
        try
        {
            Movie? existingMovie = await _context.movies.FindAsync(movieId);
            if (existingMovie is null)
            {
                return false;
            }
            _context.movies.Remove(existingMovie);
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
