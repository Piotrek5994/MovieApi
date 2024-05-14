using Core.Filter;
using Core.Model;

namespace Infrastracture.Repositories;

public interface IMovieCastRepositories
{
    Task<List<Movie_Cast>> Get(MovieCastFilter filter);
    Task<bool> CreateMovieCast(Movie_Cast movieCast);
    Task<bool> DeleteMovieCast(int movieId, int personId, int genderId);
}
