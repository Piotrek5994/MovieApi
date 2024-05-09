using Infrastracture.Db;
using Microsoft.Extensions.Logging;

namespace Infrastracture.Repositories;

public class LanguageRepositories : ILanguageRepositories
{
    private readonly MySqlDbContext _context;
    private readonly ILogger _log;

    public LanguageRepositories(MySqlDbContext context, ILogger<LanguageRepositories> log)
    {
        _context = context;
        _log = log;
    }
}
