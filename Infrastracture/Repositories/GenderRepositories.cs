using Infrastracture.Db;
using Microsoft.Extensions.Logging;

namespace Infrastracture.Repositories;

public class GenderRepositories : IGenderRepositories
{
    private readonly MySqlDbContext _context;
    private readonly ILogger _log;

    public GenderRepositories(MySqlDbContext context, ILogger<GenderRepositories> log)
    {
        _context = context;
        _log = log;
    }
}
