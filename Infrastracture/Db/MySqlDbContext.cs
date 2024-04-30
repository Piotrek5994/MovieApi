using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Db;

public class MySqlDbContext : DbContext
{
    public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options)
    {

    }
    //protected override void OnConfiguring(DbContextOptionsBuilder options)
    //{
    //    options.UseSqlite("Data Source= C:\\Users\\piotr\\Desktop\\Projekty C#\\BookMvc\\book.db");
    //}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}
