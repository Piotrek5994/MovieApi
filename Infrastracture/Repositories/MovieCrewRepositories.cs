using Core.Filter;
using Core.Model;
using Infrastracture.Db;
using Infrastracture.Helper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastracture.Repositories;

public class MovieCrewRepositories : IMovieCrewRepositories
{
    private readonly MySqlDbContext _context;
    private readonly ILogger _log;

    public MovieCrewRepositories(MySqlDbContext context, ILogger<MovieCrewRepositories> log)
    {
        _context = context;
        _log = log;
    }
    public async Task<List<Movie_Crew>> Get(MovieCrewFilter filter)
    {
        try
        {

            IQueryable<Movie_Crew> query = _context.movieCrews.AsQueryable();

            //Filters
            if (filter.Movie_Id != null)
            {
                query = query.Where(x => x.Movie_id.Equals(filter.Movie_Id));
            }
            if (filter.Person_Id != null)
            {
                query = query.Where(x => x.Person_id.Equals(filter.Person_Id));
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
            _log.LogError(ex, $"Error get MovieCrew in MySql : Message - {ex.Message}");
            return new List<Movie_Crew>();
        }
    }
    public async Task<bool> CreateMovieCrew(Movie_Crew movieCrew)
    {
        try
        {
            await _context.movieCrews.AddAsync(movieCrew);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }
        catch (SqlException ex)
        {
            _log.LogError(ex, $"Error creating MovieCrew in MySql : Message - {ex.Message}");
            return false;
        }

    }
    public async Task<bool> DeleteMovieCrew(int movieId, int personId, int departmentId)
    {
        try
        {
            object[] keyValues = new object[] { movieId, personId, departmentId };
            Movie_Crew? existingMovieCrew = await _context.movieCrews.FindAsync(keyValues);

            if (existingMovieCrew == null)
            {
                return false;
            }
            _context.movieCrews.Remove(existingMovieCrew);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (SqlException ex)
        {
            _log.LogError(ex, $"Error delete MovieCrew in MySql : Message - {ex.Message}");
            return false;
        }
    }
}
