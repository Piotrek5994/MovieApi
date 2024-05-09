using Infrastracture.Db;
using Microsoft.Extensions.Logging;

namespace Infrastracture.Repositories;

public class UserRepositories : IUserRepositories
{
    private readonly MySqlDbContext _context;
    private readonly ILogger _log;

    public UserRepositories(MySqlDbContext context, ILogger<UserRepositories> log)
    {
        _context = context;
        _log = log;
    }
}
