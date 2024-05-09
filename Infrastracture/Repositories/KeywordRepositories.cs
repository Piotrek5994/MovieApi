using Infrastracture.Db;
using Microsoft.Extensions.Logging;

namespace Infrastracture.Repositories
{
    public class KeywordRepositories : IKeywordRepositories
    {
        private readonly MySqlDbContext _context;
        private readonly ILogger _log;

        public KeywordRepositories(MySqlDbContext context, ILogger<KeywordRepositories> log)
        {
            _context = context;
            _log = log;
        }
    }
}
