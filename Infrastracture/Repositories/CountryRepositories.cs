using Infrastracture.Db;
using Microsoft.Extensions.Logging;

namespace Infrastracture.Repositories;

public class CountryRepositories : ICountryRepositories
{
    private readonly MySqlDbContext _context;
    private readonly ILogger _log;

    public CountryRepositories(MySqlDbContext context, ILogger<CountryRepositories> log)
    {
        _context = context;
        _log = log;
    }
}
