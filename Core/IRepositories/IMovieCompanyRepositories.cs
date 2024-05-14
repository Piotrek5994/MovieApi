using Core.Filter;
using Core.Model;

namespace Infrastracture.Repositories;

public interface IMovieCompanyRepositories
{
    Task<List<Movie_Company>> Get(MovieCompanyFilter filter);
    Task<bool> CreateMovieCompany(Movie_Company movieCompany);
    Task<bool> DeleteMovieCompany(int movieId, int companyId);
}
