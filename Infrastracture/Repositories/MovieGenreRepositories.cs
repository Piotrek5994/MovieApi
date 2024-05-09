using Infrastracture.Db;
using Microsoft.Extensions.Logging;

namespace Infrastracture.Repositories;

public class MovieGenreRepositories : IMovieGenreRepositories
{
    private readonly MySqlDbContext _context;
    private readonly ILogger _log;

    public MovieGenreRepositories(MySqlDbContext context, ILogger<MovieGenreRepositories> log)
    {
        _context = context;
        _log = log;
    }
}
