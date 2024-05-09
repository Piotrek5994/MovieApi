using Core.IRepositories;
using Infrastracture.Db;
using Microsoft.Extensions.Logging;

namespace Infrastracture.Repositories;

public class AuthRepositories : IAuthRepositories
{
    private readonly MySqlDbContext _context;
    private readonly ILogger _log;

    public AuthRepositories(MySqlDbContext context, ILogger<AuthRepositories> log)
    {
        _context = context;
        _log = log;
    }
}
