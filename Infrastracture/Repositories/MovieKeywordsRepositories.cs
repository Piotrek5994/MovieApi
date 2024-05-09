using Infrastracture.Db;
using Microsoft.Extensions.Logging;

namespace Infrastracture.Repositories;

public class MovieKeywordsRepositories : IMovieKeywordsRepositories
{
    private readonly MySqlDbContext _context;
    private readonly ILogger _log;

    public MovieKeywordsRepositories(MySqlDbContext context, ILogger<MovieKeywordsRepositories> log)
    {
        _context = context;
        _log = log;
    }
}
