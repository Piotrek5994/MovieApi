using AutoMapper;
using Core.CommandDto;
using Core.Filter;
using Core.Model;
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
    public async Task<List<Movie_User>> Get(UserFilter filter)
    {
        List<Movie_User> result = await _userRepositories.Get(filter);
        return result;
    }
    public async Task<int> Post(Create_Movie_User_Dto userdto)
    {
        Movie_User mappedUser = _mapper.Map<Create_Movie_User_Dto,Movie_User>(userdto);
        int createUserDto = await _userRepositories.CreateUser(mappedUser);
        return createUserDto;
    }
}
