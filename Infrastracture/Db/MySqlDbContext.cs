using Core.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Db;

public class MySqlDbContext : DbContext
{
    public DbSet<Movie> movies { get; set; }
    public DbSet<Movie_Company> movieCompanies { get; set; }
    public DbSet<Movie_Cast> movieCasts { get; set; }
    public DbSet<Movie_Crew> movieCrews { get; set; }
    public DbSet<Production_Company> productionCompanies { get; set; }
    public DbSet<Gender> genders { get; set; }
    public DbSet<Person> persons { get; set; }
    public DbSet<Department> departments { get; set; }
    public DbSet<Production_Country> productionCountries { get; set; }
    public DbSet<Movie_Languages> movieLanguages { get; set; }
    public DbSet<Movie_Genre> movieGenres { get; set; }
    public DbSet<Movie_Keywords> movieKeywords { get; set; }
    public DbSet<Country> countries { get; set; }
    public DbSet<Language> languages { get; set; }
    public DbSet<Language_Role> languagesRoles { get; set; }
    public DbSet<Genre> genres { get; set; }
    public DbSet<Keyword> keywords { get; set; }
    public DbSet<Movie_User> users { get; set; }
    public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options)
    {

    }
    //protected override void OnConfiguring(DbContextOptionsBuilder options)
    //{
    //    options.UseSqlite("Data Source= C:\\Users\\piotr\\Desktop\\Projekty C#\\BookMvc\\book.db");
    //}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Movie_User>(entity =>
        {
            entity.HasKey(mu => mu.User_id);

            entity.HasMany(mu => mu.Movie)
                  .WithOne(m => m.User)
                  .HasForeignKey(m => m.Movie_id);
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(m => m.Movie_id);

            entity.HasOne(m => m.User)
                  .WithMany(mu => mu.Movie)
                  .HasForeignKey(m => m.Movie_id);
        });

        modelBuilder.Entity<Movie_Company>(entity =>
        {
            entity.HasKey(mc => new { mc.Movie_id, mc.Compnay_id });
        });

        modelBuilder.Entity<Production_Company>(entity =>
        {
            entity.HasKey(pc => pc.Company_id);
        });

        modelBuilder.Entity<Movie_Cast>(entity =>
        {
            entity.HasKey(ct => new { ct.Movie_id, ct.Gender_id, ct.Person_id});
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(g => g.Gender_id);
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(p => p.Person_id);
        });

        modelBuilder.Entity<Movie_Crew>(entity =>
        {
            entity.HasKey(mc => new { mc.Person_id, mc.Movie_id, mc.Department_id });
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(d => d.Department_id);
        });

        modelBuilder.Entity<Production_Country>(entity =>
        {
            entity.HasKey(pc => new { pc.Movie_id, pc.Country_id });
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(c => c.Country_id);
        });

        modelBuilder.Entity<Movie_Languages>(entity =>
        {
            entity.HasKey(ml => new { ml.Movie_id, ml.Language_id, ml.Language_Role_id });
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(l => l.Language_id);
        });

        modelBuilder.Entity<Language_Role>(entity =>
        {
            entity.HasKey(lr => lr.Role_id);
        });

        modelBuilder.Entity<Movie_Genre>(entity =>
        {
            entity.HasKey(mg => new { mg.Movie_id, mg.Genre_id });
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(g => g.Genre_id);
        });

        modelBuilder.Entity<Movie_Keywords>(entity =>
        {
            entity.HasKey(mk => new { mk.Movie_Id, mk.Keyword_Id });
        });

        modelBuilder.Entity<Keyword>(entity =>
        {
            entity.HasKey(k => k.Keyword_id);
        });
    }
}
