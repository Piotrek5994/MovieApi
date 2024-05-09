using Infrastracture.Db;
using Microsoft.Extensions.Logging;

namespace Infrastracture.Repositories;

public class ProductionCompanyRepositories : IProductionCompanyRepositories
{
    private readonly MySqlDbContext _context;
    private readonly ILogger _log;

    public ProductionCompanyRepositories(MySqlDbContext context, ILogger<ProductionCompanyRepositories> log)
    {
        _context = context;
        _log = log;
    }
}
