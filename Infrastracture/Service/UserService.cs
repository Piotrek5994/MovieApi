using AutoMapper;
using Core.CommandDto;
using Core.Filter;
using Core.Model;
using Core.ModelDto;
using Infrastracture.Repositories;
using Infrastracture.Service.IService;

namespace Infrastracture.Service;

public class UserService : IUserService
{
    private readonly IUserRepositories _userRepositories;
    private readonly IMapper _mapper;

    public UserService(IUserRepositories userRepositories, IMapper mapper)
    {
        _userRepositories = userRepositories;
        _mapper = mapper;
    }
    public async Task<List<Movie_User_Dto>> Get(UserFilter filter)
    {
        List<Movie_User> getUserList = await _userRepositories.Get(filter);
        List<Movie_User_Dto> mappedUser = _mapper.Map<List<Movie_User_Dto>>(getUserList);
        return mappedUser;
    }
    public async Task<int> Post(Create_Movie_User_Dto userdto)
    {
        Movie_User mappedUser = _mapper.Map<Movie_User>(userdto);
        int createUserDto = await _userRepositories.CreateUser(mappedUser);
        return createUserDto;
    }
    public async Task<bool> Put(Create_Movie_User_Dto userDto , int userId)
    {
        Movie_User mappedUser = _mapper.Map<Movie_User>(userDto);
        bool changeUser = await _userRepositories.UpdateUser(mappedUser,userId);
        return changeUser;
    }
    public async Task<bool> Delete(int userId)
    {
        bool deleteResult = await _userRepositories.DeleteUser(userId);
        return deleteResult;
    }
}
