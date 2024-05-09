using Core.Filter;
using Core.Model;

namespace Infrastracture.Repositories;

public interface IUserRepositories
{
    Task<List<Movie_User>> Get(UserFilter filter);
}
