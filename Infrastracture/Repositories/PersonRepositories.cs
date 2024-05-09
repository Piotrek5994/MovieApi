using Infrastracture.Db;
using Microsoft.Extensions.Logging;

namespace Infrastracture.Repositories;

public class PersonRepositories : IPersonRepositories
{
    private readonly MySqlDbContext _context;
    private readonly ILogger _log;

    public PersonRepositories(MySqlDbContext context, ILogger<PersonRepositories> log)
    {
        _context = context;
        _log = log;
    }
}
