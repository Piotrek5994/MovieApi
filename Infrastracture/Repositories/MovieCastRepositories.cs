using Core.Filter;
using Core.Model;
using Infrastracture.Db;
using Infrastracture.Helper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastracture.Repositories;

public class MovieCastRepositories : IMovieCastRepositories
{
    private readonly MySqlDbContext _context;
    private readonly ILogger _log;

    public MovieCastRepositories(MySqlDbContext context, ILogger<MovieCastRepositories> log)
    {
        _context = context;
        _log = log;
    }
    public async Task<List<Movie_Cast>> Get(MovieCastFilter filter)
    {
        try
        {
            IQueryable<Movie_Cast> query = _context.movieCasts.AsQueryable();

            //Filters
            if (filter.Movie_Id != null)
            {
                query = query.Where(x => x.Movie_id.Equals(filter.Movie_Id));
            }
            if (filter.Person_Id != null)
            {
                query = query.Where(x => x.Person_id.Equals(filter.Person_Id));
            }
            if (filter.Gender_Id != null)
            {
                query = query.Where(x => x.Gender_id.Equals(filter.Gender_Id));
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
            _log.LogError(ex, $"Error get MovieCast in MySql : Message - {ex.Message}");
            return new List<Movie_Cast>();
        }
    }
    public async Task<bool> CreateMovieCast(Movie_Cast movieCast)
    {
        try
        {
            await _context.movieCasts.AddAsync(movieCast);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }
        catch (SqlException ex)
        {
            _log.LogError(ex, $"Error creating MovieCast in MySql : Message - {ex.Message}");
            return false;
        }
    }
    public async Task<bool> DeleteMovieCast(int movieId, int personId, int genderId)
    {
        try
        {
            object[] keyValues = new object[] { movieId, personId, genderId };
            Movie_Cast? existingMovieCast = await _context.movieCasts.FindAsync(keyValues);

            if (existingMovieCast == null)
            {
                return false;
            }
            _context.movieCasts.Remove(existingMovieCast);
            await _context.SaveChangesAsync();
            return true;

        }
        catch (SqlException ex)
        {
            _log.LogError(ex, $"Error delete MovieCast in MySql : Message - {ex.Message}");
            return false;
        }
    }
}
