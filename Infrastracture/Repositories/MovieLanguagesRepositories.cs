using Infrastracture.Db;
using Microsoft.Extensions.Logging;

namespace Infrastracture.Repositories;

public class MovieLanguagesRepositories : IMovieLanguagesRepositories
{
    private readonly MySqlDbContext _context;
    private readonly ILogger _log;

    public MovieLanguagesRepositories(MySqlDbContext context, ILogger<MovieLanguagesRepositories> log)
    {
        _context = context;
        _log = log;
    }
}
