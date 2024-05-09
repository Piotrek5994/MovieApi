using Infrastracture.Db;
using Microsoft.Extensions.Logging;

namespace Infrastracture.Repositories;

public class ProductionCountryRepositories : IProductionCountryRepositories
{
    private readonly MySqlDbContext _context;
    private readonly ILogger _log;

    public ProductionCountryRepositories(MySqlDbContext context, ILogger<ProductionCompanyRepositories> log)
    {
        _context = context;
        _log = log;
    }
}
