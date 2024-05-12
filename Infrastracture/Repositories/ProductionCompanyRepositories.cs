using Core.Filter;
using Core.Model;
using Infrastracture.Db;
using Infrastracture.Helper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Reflection;

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
    public async Task<List<Production_Company>> Get(ProductionCompanyFilter filter)
    {
        try
        {

            IQueryable<Production_Company> query = _context.productionCompanies.AsQueryable();

            //Filters
            if (filter.Id != null)
            {
                query = query.Where(x => x.Company_id.Equals(filter.Id));
            }

            //Sort
            if (!string.IsNullOrEmpty(filter.SortBy))
            {
                query = SortHelper.ApplyDynamicSorting(query, filter.SortBy, filter.SortDirection);
            }

            //Pagination
            query = query.Skip((filter.Page - 1) * filter.Limit).Take(filter.Limit);

            var result = await query.ToListAsync().ConfigureAwait(false);
            return result;
        }
        catch (SqlException ex)
        {
            _log.LogError(ex, $"Error get ProductionCompany in MySql : Message - {ex.Message}");
            return new List<Production_Company>();

        }
    }
    public async Task<int> CreateProductionCompany(Production_Company productionCompany)
    {
        try
        {
            await _context.productionCompanies.AddAsync(productionCompany);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return productionCompany.Company_id;
        }
        catch (SqlException ex)
        {
            _log.LogError(ex, $"Error creating ProductionCompany in MySql : Message - {ex.Message}");
            return 0;
        }

    }
    public async Task<bool> UpdateProductionCompany(Production_Company productionCompany, int productionCompanyId)
    {
        try
        {
            Production_Company? existingProductionCompany = await _context.productionCompanies.FindAsync(productionCompanyId);
            PropertyInfo[] properties = typeof(Production_Company).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType == typeof(string))
                {
                    string newValue = (string)property.GetValue(productionCompany);
                    string existingValue = (string)property.GetValue(existingProductionCompany);
                    if (!string.IsNullOrEmpty(newValue) && newValue != existingValue)
                    {
                        property.SetValue(existingProductionCompany, newValue);
                    }
                }
            }
            await _context.SaveChangesAsync();
            return true;
        }
        catch (SqlException ex)
        {
            _log.LogError(ex, $"Error updating ProductionCompany in MySql : Message - {ex.Message}");
            return false;
        }
    }
    public async Task<bool> DeleteProductionCompany(int productionCompanyId)
    {
        try
        {
            Production_Company? existingproductionCompany = await _context.productionCompanies.FindAsync(productionCompanyId);
            if (existingproductionCompany is null)
            {
                return false;
            }
            _context.productionCompanies.Remove(existingproductionCompany);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (SqlException ex)
        {
            _log.LogError(ex, $"Error delete ProductionCompany in MySql : Message - {ex.Message}");
            return false;
        }
    }
}
