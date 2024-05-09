using Core.Filter;
using Core.Model;

namespace Infrastracture.Service.IService;

public interface IUserService
{
    Task<List<Movie_User>> Get(UserFilter filter);
}
