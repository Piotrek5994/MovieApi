using Infrastracture.Db;
using Microsoft.Extensions.Logging;

namespace Infrastracture.Repositories;

public class DepartmentRepositories : IDepartmentRepositories
{
    private readonly MySqlDbContext _context;
    private readonly ILogger _log;

    public DepartmentRepositories(MySqlDbContext context, ILogger<DepartmentRepositories> log)
    {
        _context = context;
        _log = log;
    }
}
