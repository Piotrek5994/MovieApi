using Core.Filter;
using Core.Model;

namespace Infrastracture.Repositories;

public interface IMovieCrewRepositories
{
    Task<List<Movie_Crew>> Get(MovieCrewFilter filter);
    Task<bool> CreateMovieCrew(Movie_Crew movieCrew);
    Task<bool> DeleteMovieCrew(int movieId, int personId, int departmentId);
}
