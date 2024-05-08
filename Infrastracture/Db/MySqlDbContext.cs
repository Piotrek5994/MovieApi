using Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
    //public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options)
    //{
    //}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = "server=localhost;database=movies;User=root;Password=";
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

            entity.HasMany(m => m.MovieCompany)
                  .WithOne(mc => mc.Movies)
                  .HasForeignKey(m => m.Movie_id);

            entity.HasMany(m => m.MovieCast)
                  .WithOne(mc => mc.Movies)
                  .HasForeignKey(m => m.Movie_id);

            entity.HasMany(m => m.MovieCrew)
                  .WithOne(mc => mc.Movie)
                  .HasForeignKey(m => m.Movie_id);

            entity.HasMany(m => m.ProductionCountry)
                  .WithOne(pc => pc.Movies)
                  .HasForeignKey(m => m.Movie_id);

            entity.HasMany(m => m.MovieLanguages)
                  .WithOne(ml => ml.Movies)
                  .HasForeignKey(m => m.Movie_id);

            entity.HasMany(m => m.MovieGenre)
                  .WithOne(mg => mg.Movies)
                  .HasForeignKey(m => m.Movie_id);

            entity.HasMany(m => m.MovieKeywords)
                  .WithOne(mk => mk.Movies)
                  .HasForeignKey(m => m.Movie_Id);
        });

        modelBuilder.Entity<Movie_Company>(entity =>
        {
            entity.HasKey(mc => new { mc.Movie_id, mc.Company_id });

            entity.HasOne(mc => mc.Movies)
                  .WithMany(m => m.MovieCompany)
                  .HasForeignKey(m => m.Movie_id);

            entity.HasOne(mc => mc.ProductionCompany)
                  .WithMany(pc => pc.MovieCompany)
                  .HasForeignKey(pc => pc.Company_id);
        });

        modelBuilder.Entity<Production_Company>(entity =>
        {
            entity.HasKey(pc => pc.Company_id);

            entity.HasMany(pc => pc.MovieCompany)
                  .WithOne(mc => mc.ProductionCompany)
                  .HasForeignKey(pc => pc.Company_id);
        });

        modelBuilder.Entity<Movie_Cast>(entity =>
        {
            entity.HasKey(mc => new { mc.Movie_id, mc.Gender_id, mc.Person_id });

            entity.HasOne(mc => mc.Movies)
                  .WithMany(m => m.MovieCast)
                  .HasForeignKey(m => m.Movie_id);

            entity.HasOne(mc => mc.Genders)
                  .WithMany(g => g.MovieCast)
                  .HasForeignKey(g => g.Gender_id);

            entity.HasOne(mc => mc.Persons)
                  .WithMany(p => p.MovieCast)
                  .HasForeignKey(p => p.Person_id);
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(g => g.Gender_id);

            entity.HasMany(g => g.MovieCast)
                  .WithOne(mc => mc.Genders)
                  .HasForeignKey(g => g.Gender_id);
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(p => p.Person_id);

            entity.HasMany(p => p.MovieCast)
                  .WithOne(mc => mc.Persons)
                  .HasForeignKey(p => p.Person_id);

            entity.HasMany(p => p.MovieCrew)
                  .WithOne(mc => mc.Persons)
                  .HasForeignKey(p =>p.Person_id);
        });

        modelBuilder.Entity<Movie_Crew>(entity =>
        {
            entity.HasKey(mc => new { mc.Person_id, mc.Movie_id, mc.Department_id });

            entity.HasOne(mc => mc.Movie)
                  .WithMany(m => m.MovieCrew)
                  .HasForeignKey(m => m.Movie_id);

            entity.HasOne(mc => mc.Persons)
                  .WithMany(p => p.MovieCrew)
                  .HasForeignKey(p => p.Person_id);

            entity.HasOne(mc => mc.Departments)
                  .WithMany(d => d.MovieCrew)
                  .HasForeignKey(d => d.Department_id);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(d => d.Department_id);

            entity.HasMany(d => d.MovieCrew)
                  .WithOne(mc => mc.Departments)
                  .HasForeignKey(d => d.Department_id);
        });

        modelBuilder.Entity<Production_Country>(entity =>
        {
            entity.HasKey(pc => new { pc.Movie_id, pc.Country_id });

            entity.HasOne(pc => pc.Movies)
                  .WithMany(m => m.ProductionCountry)
                  .HasForeignKey(m => m.Movie_id);

            entity.HasOne(pc => pc.Countries)
                  .WithMany(c => c.ProductionCountry)
                  .HasForeignKey(c => c.Country_id);
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(c => c.Country_id);

            entity.HasMany(c => c.ProductionCountry)
                  .WithOne(pc => pc.Countries)
                  .HasForeignKey(c => c.Country_id);
        });

        modelBuilder.Entity<Movie_Languages>(entity =>
        {
            entity.HasKey(ml => new { ml.Movie_id, ml.Language_id, ml.Language_Role_id });

            entity.HasOne(ml => ml.Movies)
                  .WithMany(m => m.MovieLanguages)
                  .HasForeignKey(m => m.Movie_id);

            entity.HasOne(ml => ml.Languages)
                  .WithMany(l => l.MovieLanguages)
                  .HasForeignKey(l => l.Language_id);

            entity.HasOne(ml => ml.LanguageRoles)
                  .WithMany(lr => lr.MovieLanguages)
                  .HasForeignKey(ml => ml.Language_Role_id);;
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(l => l.Language_id);

            entity.HasMany(l => l.MovieLanguages)
                  .WithOne(ml => ml.Languages)
                  .HasForeignKey(l => l.Language_id);
        });

        modelBuilder.Entity<Language_Role>(entity =>
        {
            entity.HasKey(lr => lr.Role_id);

            entity.HasMany(lr => lr.MovieLanguages)
                  .WithOne(ml => ml.LanguageRoles)
                  .HasForeignKey(ml => ml.Language_Role_id);
        });

        modelBuilder.Entity<Movie_Genre>(entity =>
        {
            entity.HasKey(mg => new { mg.Movie_id, mg.Genre_id });

            entity.HasOne(mg => mg.Movies)
                  .WithMany(m => m.MovieGenre)
                  .HasForeignKey(m => m.Movie_id);

            entity.HasOne(mg => mg.Genres)
                  .WithMany(g => g.MovieGenre)
                  .HasForeignKey(g => g.Genre_id);
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(g => g.Genre_id);

            entity.HasMany(g => g.MovieGenre)
                  .WithOne(mg => mg.Genres)
                  .HasForeignKey(g => g.Genre_id);
        });

        modelBuilder.Entity<Movie_Keywords>(entity =>
        {
            entity.HasKey(mk => new { mk.Movie_Id, mk.Keyword_Id });

            entity.HasOne(mk => mk.Movies)
                  .WithMany(m => m.MovieKeywords)
                  .HasForeignKey(m => m.Movie_Id);

            entity.HasOne(mk => mk.Keywords)
                  .WithMany(k => k.MovieKeywords)
                  .HasForeignKey(k => k.Keyword_Id);
        });

        modelBuilder.Entity<Keyword>(entity =>
        {
            entity.HasKey(k => k.Keyword_id);

            entity.HasMany(k => k.MovieKeywords)
                  .WithOne(mk => mk.Keywords)
                  .HasForeignKey(k => k.Keyword_Id);
        });
    }
}
