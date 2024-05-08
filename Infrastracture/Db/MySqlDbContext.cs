using Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastracture.Db;

public class MySqlDbContext : DbContext
{
    private readonly IConfiguration _configuration;
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
    public MySqlDbContext(DbContextOptions<MySqlDbContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = _configuration.GetConnectionString("localDb");
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Movie_User>(entity =>
        {
            entity.HasKey(mu => mu.User_id);

            entity.HasMany(mu => mu.Movie)
                  .WithOne(m => m.User)
                  .HasForeignKey(m => m.User_id);
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(m => m.Movie_id);

            entity.HasOne(m => m.User)
                  .WithMany(u => u.Movie)
                  .HasForeignKey(m => m.Movie_id);

            entity.HasOne(m => m.MovieCompany)
                  .WithMany(mc => mc.Movies)
                  .HasForeignKey(m => m.Movie_id);

            entity.HasOne(m => m.MovieCast)
                  .WithMany(mc => mc.Movies)
                  .HasForeignKey(m => m.Movie_id);

            entity.HasOne(m => m.MovieCrew)
                  .WithMany(mc => mc.Movie)
                  .HasForeignKey(m => m.Movie_id);

            entity.HasOne(m => m.ProductionCountry)
                  .WithMany(pc => pc.Movies)
                  .HasForeignKey(m => m.ProductionCountry);

            entity.HasOne(m => m.MovieLanguages)
                  .WithMany(ml => ml.Movies)
                  .HasForeignKey(m => m.MovieLanguages);

            entity.HasOne(m => m.MovieGenre)
                  .WithMany(mg => mg.Movies)
                  .HasForeignKey(m => m.MovieGenre);

            entity.HasOne(m => m.MovieKeywords)
                  .WithMany(mk => mk.Movies)
                  .HasForeignKey(m => m.MovieKeywords);
        });

        modelBuilder.Entity<Movie_Company>(entity =>
        {
            entity.HasKey(mc => new { mc.Movie_id, mc.Company_id });

            entity.HasMany(mc => mc.Movies)
                  .WithOne(m => m.MovieCompany)
                  .HasForeignKey(m => m.Movie_id);

            entity.HasMany(mc => mc.ProductionCompany)
                  .WithOne(pc => pc.MovieCompany)
                  .HasForeignKey(pc => pc.Company_id);
        });

        modelBuilder.Entity<Production_Company>(entity =>
        {
            entity.HasKey(pc => pc.Company_id);

            entity.HasOne(pc => pc.MovieCompany)
                  .WithMany(mc => mc.ProductionCompany)
                  .HasForeignKey(pc => pc.Company_id);
        });

        modelBuilder.Entity<Movie_Cast>(entity =>
        {
            entity.HasKey(mc => new { mc.Movie_id, mc.Gender_id, mc.Person_id });

            entity.HasMany(mc => mc.Movies)
                  .WithOne(m => m.MovieCast)
                  .HasForeignKey(m => m.Movie_id);

            entity.HasMany(mc => mc.Genders)
                  .WithOne(g => g.MovieCast)
                  .HasForeignKey(g => g.Gender_id);

            entity.HasMany(mc => mc.Persons)
                  .WithOne(p => p.MovieCast)
                  .HasForeignKey(p => p.Person_id);
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(g => g.Gender_id);

            entity.HasOne(g => g.MovieCast)
                  .WithMany(mc => mc.Genders)
                  .HasForeignKey(g => g.Gender_id);
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(p => p.Person_id);

            entity.HasOne(p => p.MovieCast)
                  .WithMany(mc => mc.Persons)
                  .HasForeignKey(p => p.Person_id);

            entity.HasOne(p => p.MovieCrew)
                  .WithMany(mc => mc.Persons)
                  .HasForeignKey(p =>p.Person_id);
        });

        modelBuilder.Entity<Movie_Crew>(entity =>
        {
            entity.HasKey(mc => new { mc.Person_id, mc.Movie_id, mc.Department_id });

            entity.HasMany(mc => mc.Movie)
                  .WithOne(m => m.MovieCrew)
                  .HasForeignKey(m => m.Movie_id);

            entity.HasMany(mc => mc.Persons)
                  .WithOne(p => p.MovieCrew)
                  .HasForeignKey(p => p.Person_id);

            entity.HasMany(mc => mc.Departments)
                  .WithOne(d => d.MovieCrew)
                  .HasForeignKey(d => d.Department_id);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(d => d.Department_id);

            entity.HasOne(d => d.MovieCrew)
                  .WithMany(mc => mc.Departments)
                  .HasForeignKey(d => d.Department_id);
        });

        modelBuilder.Entity<Production_Country>(entity =>
        {
            entity.HasKey(pc => new { pc.Movie_id, pc.Country_id });

            entity.HasMany(pc => pc.Movies)
                  .WithOne(m => m.ProductionCountry)
                  .HasForeignKey(m => m.Movie_id);

            entity.HasMany(pc => pc.Countries)
                  .WithOne(c => c.ProductionCountry)
                  .HasForeignKey(c => c.Country_id);
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(c => c.Country_id);

            entity.HasOne(c => c.ProductionCountry)
                  .WithMany(pc => pc.Countries)
                  .HasForeignKey(c => c.Country_id);
        });

        modelBuilder.Entity<Movie_Languages>(entity =>
        {
            entity.HasKey(ml => new { ml.Movie_id, ml.Language_id, ml.Language_Role_id });

            entity.HasMany(ml => ml.Movies)
                  .WithOne(m => m.MovieLanguages)
                  .HasForeignKey(m => m.Movie_id);

            entity.HasMany(ml => ml.Languages)
                  .WithOne(l => l.MovieLanguages)
                  .HasForeignKey(l => l.Language_id);

            entity.HasMany(ml => ml.LanguageRoles)
                  .WithOne(lr => lr.MovieLanguages)
                  .HasForeignKey(lr => lr.Role_id);
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(l => l.Language_id);

            entity.HasOne(l => l.MovieLanguages)
                  .WithMany(ml => ml.Languages)
                  .HasForeignKey(l => l.Language_id);
        });

        modelBuilder.Entity<Language_Role>(entity =>
        {
            entity.HasKey(lr => lr.Role_id);

            entity.HasOne(lr => lr.MovieLanguages)
                  .WithMany(ml => ml.LanguageRoles)
                  .HasForeignKey(lr => lr.Role_id);
        });

        modelBuilder.Entity<Movie_Genre>(entity =>
        {
            entity.HasKey(mg => new { mg.Movie_id, mg.Genre_id });

            entity.HasMany(mg => mg.Movies)
                  .WithOne(m => m.MovieGenre)
                  .HasForeignKey(m => m.Movie_id);

            entity.HasMany(mg => mg.Genres)
                  .WithOne(g => g.MovieGenre)
                  .HasForeignKey(g => g.Genre_id);
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(g => g.Genre_id);

            entity.HasOne(g => g.MovieGenre)
                  .WithMany(mg => mg.Genres)
                  .HasForeignKey(g => g.Genre_id);
        });

        modelBuilder.Entity<Movie_Keywords>(entity =>
        {
            entity.HasKey(mk => new { mk.Movie_Id, mk.Keyword_Id });

            entity.HasMany(mk => mk.Movies)
                  .WithOne(m => m.MovieKeywords)
                  .HasForeignKey(m => m.Movie_id);

            entity.HasMany(mk => mk.Keywords)
                  .WithOne(k => k.MovieKeywords)
                  .HasForeignKey(k => k.Keyword_id);
        });

        modelBuilder.Entity<Keyword>(entity =>
        {
            entity.HasKey(k => k.Keyword_id);

            entity.HasOne(k => k.MovieKeywords)
                  .WithMany(mk => mk.Keywords)
                  .HasForeignKey(k => k.Keyword_id);
        });
    }
}
