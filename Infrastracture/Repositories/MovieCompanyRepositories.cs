using Infrastracture.Db;
using Microsoft.Extensions.Logging;

namespace Infrastracture.Repositories;

public class MovieCompanyRepositories : IMovieCompanyRepositories
{
    private readonly MySqlDbContext _context;
    private readonly ILogger _log;

    public MovieCompanyRepositories(MySqlDbContext context, ILogger<MovieCompanyRepositories> log)
    {
        _context = context;
        _log = log;
    }
}
