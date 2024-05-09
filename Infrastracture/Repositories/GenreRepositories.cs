using Infrastracture.Db;
using Microsoft.Extensions.Logging;

namespace Infrastracture.Repositories;

public class GenreRepositories : IGenreRepositories
{
    private readonly MySqlDbContext _context;
    private readonly ILogger _log;

    public GenreRepositories(MySqlDbContext context, ILogger<GenreRepositories> log)
    {
        _context = context;
        _log = log;
    }
}
