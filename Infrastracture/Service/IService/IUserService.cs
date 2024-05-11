using Core.CommandDto;
using Core.Filter;
using Core.ModelDto;

namespace Infrastracture.Service.IService;

public interface IUserService
{
    Task<List<Movie_User_Dto>> Get(UserFilter filter);
    Task<int> Post(Create_Movie_User_Dto userdto);
    Task<bool> Put(Create_Movie_User_Dto userDto, int userId);
    Task<bool> Delete(int userId);
}
