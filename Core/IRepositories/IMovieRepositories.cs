using Core.Filter;
using Core.Model;

namespace Core.IRepositories;

public interface IMovieRepositories
{
    Task<List<Movie>> Get(MovieFilter filter);
    Task<int> CreateMovie(Movie movie);
    Task<bool> UpdateMovie(Movie movie, int movieId);
    Task<bool> DeleteMovie(int movieId);
}
