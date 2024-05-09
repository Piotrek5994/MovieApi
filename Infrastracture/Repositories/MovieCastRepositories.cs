using Infrastracture.Db;
using Microsoft.Extensions.Logging;

namespace Infrastracture.Repositories;

public class MovieCastRepositories : IMovieCastRepositories
{
    private readonly MySqlDbContext _context;
    private readonly ILogger _log;

    public MovieCastRepositories(MySqlDbContext context, ILogger<MovieCastRepositories> log)
    {
        _context = context;
        _log = log;
    }
}
