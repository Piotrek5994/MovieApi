using Core.Filter;
using Core.Model;

namespace Infrastracture.Repositories;

public interface IUserRepositories
{
    Task<List<Movie_User>> Get(UserFilter filter);
    Task<int> CreateUser(Movie_User user);
    Task<bool> UpdateUser(Movie_User user, int userId);
    Task<bool> DeleteUser(int userId);

}
