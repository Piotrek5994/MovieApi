using Infrastracture.Db;
using Microsoft.Extensions.Logging;

namespace Infrastracture.Repositories;

public class MovieCrewRepositories : IMovieCrewRepositories
{
    private readonly MySqlDbContext _context;
    private readonly ILogger _log;

    public MovieCrewRepositories(MySqlDbContext context, ILogger<MovieCrewRepositories> log)
    {
        _context = context;
        _log = log;
    }
}
