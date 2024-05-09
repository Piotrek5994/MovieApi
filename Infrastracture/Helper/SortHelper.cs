using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture.Helper;

public static class SortHelper
{
    public static IQueryable<T> ApplyDynamicSorting<T>(IQueryable<T> query, string sortBy, int? sortDirection)
    {
        bool isAscending = sortDirection.HasValue && sortDirection.Value == 1;
        
        bool propertyExists = typeof(T).GetProperty(sortBy,BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) != null;

        if(!propertyExists)
        {
            return query;
        }

        if (isAscending)
        {
            query = query.OrderBy(x => x != null ? EF.Property<object>(x, sortBy) : null);
        }
        else
        {
            query = query.OrderByDescending(x => x != null ? EF.Property<object>(x, sortBy) : null);
        }

        return query;
    }
}
