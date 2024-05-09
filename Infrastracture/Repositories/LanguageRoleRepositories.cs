using Infrastracture.Db;
using Microsoft.Extensions.Logging;

namespace Infrastracture.Repositories;

public class LanguageRoleRepositories : ILanguageRoleRepositories
{
    private readonly MySqlDbContext _context;
    private readonly ILogger _log;

    public LanguageRoleRepositories(MySqlDbContext context, ILogger<LanguageRoleRepositories> log)
    {
        _context = context;
        _log = log;
    }
}
