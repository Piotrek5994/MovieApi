using Core.Filter;
using Core.Model;
using Infrastracture.Db;
using Infrastracture.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastracture.Repositories;

public class UserRepositories : IUserRepositories
{
    private readonly MySqlDbContext _context;
    private readonly ILogger _log;

    public UserRepositories(MySqlDbContext context, ILogger<UserRepositories> log)
    {
        _context = context;
        _log = log;
    }
    public async Task<List<Movie_User>> Get(UserFilter filter)
    {
        IQueryable<Movie_User> query =  _context.users.AsQueryable();

        //Filters
        if (filter.Id != null)
        {
            query = query.Where(x => x.User_id.Equals(filter.Id));
        }

        //Sort
        if(!string.IsNullOrEmpty(filter.SortBy))
        {
            query = SortHelper.ApplyDynamicSorting(query,filter.SortBy,filter.SortDirection);
        }

        //Pagination
        query = query.Skip((filter.page-1) * filter.limit).Take(filter.limit);

        var result = await query.ToListAsync().ConfigureAwait(false);
        return result;
    }
}
