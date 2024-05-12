using Core.Filter;
using Core.Model;

namespace Infrastracture.Repositories;

public interface IMovieCompanyRepositories
{
    Task<List<Movie_Company>> Get(MovieCompanyFilter filter);
    Task<int> CreateMovieCompany(Movie_Company movieCompany);
    Task<bool> UpdateMovieCompany(Movie_Company movieCompany, int movieComapnyId);
    Task<bool> DeleteMovieCompany(int movieCompanyId);
}
