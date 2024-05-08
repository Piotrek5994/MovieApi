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
    public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options)
    {
    }
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    if (!optionsBuilder.IsConfigured)
    //    {
    //        var connectionString = "server=localhost;database=movies;User=root;Password=";
    //        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    //    }
    //}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Movie_User>(entity =>
        {
            entity.ToTable("Movie_User");

            entity.HasKey(mu => mu.User_id);

            entity.HasMany(mu => mu.Movie)
                  .WithOne(m => m.User)
                  .HasForeignKey(m => m.User_id);
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.ToTable("Movie");

            entity.HasKey(m => m.Movie_id);

            entity.HasOne(m => m.User)
                  .WithMany(u => u.Movie)
                  .HasForeignKey(m => m.User_id);

            entity.HasMany(m => m.MovieCompany)
                  .WithOne(mc => mc.Movie)
                  .HasForeignKey(m => m.Movie_id);

            entity.HasMany(m => m.MovieCast)
                  .WithOne(mc => mc.Movie)
                  .HasForeignKey(m => m.Movie_id);

            entity.HasMany(m => m.MovieCrew)
                  .WithOne(mc => mc.Movie)
                  .HasForeignKey(m => m.Movie_id);

            entity.HasMany(m => m.ProductionCountry)
                  .WithOne(pc => pc.Movie)
                  .HasForeignKey(m => m.Movie_id);

            entity.HasMany(m => m.MovieLanguages)
                  .WithOne(ml => ml.Movie)
                  .HasForeignKey(m => m.Movie_id);

            entity.HasMany(m => m.MovieGenre)
                  .WithOne(mg => mg.Movie)
                  .HasForeignKey(m => m.Movie_id);

            entity.HasMany(m => m.MovieKeywords)
                  .WithOne(mk => mk.Movie)
                  .HasForeignKey(m => m.Movie_Id);
        });

        modelBuilder.Entity<Movie_Company>(entity =>
        {
            entity.ToTable("Movie_Company");

            entity.HasKey(mc => new { mc.Movie_id, mc.Company_id });

            entity.HasOne(mc => mc.Movie)
                  .WithMany(m => m.MovieCompany)
                  .HasForeignKey(m => m.Movie_id);

            entity.HasOne(mc => mc.ProductionCompany)
                  .WithMany(pc => pc.MovieCompany)
                  .HasForeignKey(pc => pc.Company_id);
        });

        modelBuilder.Entity<Production_Company>(entity =>
        {
            entity.ToTable("Production_Company");

            entity.HasKey(pc => pc.Company_id);

            entity.HasMany(pc => pc.MovieCompany)
                  .WithOne(mc => mc.ProductionCompany)
                  .HasForeignKey(pc => pc.Company_id);
        });

        modelBuilder.Entity<Movie_Cast>(entity =>
        {
            entity.ToTable("Movie_Cast");

            entity.HasKey(mc => new { mc.Movie_id, mc.Gender_id, mc.Person_id });

            entity.HasOne(mc => mc.Movie)
                  .WithMany(m => m.MovieCast)
                  .HasForeignKey(m => m.Movie_id);

            entity.HasOne(mc => mc.Gender)
                  .WithMany(g => g.MovieCast)
                  .HasForeignKey(g => g.Gender_id);

            entity.HasOne(mc => mc.Person)
                  .WithMany(p => p.MovieCast)
                  .HasForeignKey(p => p.Person_id);
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.ToTable("Gender");

            entity.HasKey(g => g.Gender_id);

            entity.HasMany(g => g.MovieCast)
                  .WithOne(mc => mc.Gender)
                  .HasForeignKey(g => g.Gender_id);
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.ToTable("Person");

            entity.HasKey(p => p.Person_id);

            entity.HasMany(p => p.MovieCast)
                  .WithOne(mc => mc.Person)
                  .HasForeignKey(p => p.Person_id);

            entity.HasMany(p => p.MovieCrew)
                  .WithOne(mc => mc.Person)
                  .HasForeignKey(p =>p.Person_id);
        });

        modelBuilder.Entity<Movie_Crew>(entity =>
        {
            entity.ToTable("Movie_Crew");

            entity.HasKey(mc => new { mc.Person_id, mc.Movie_id, mc.Department_id });

            entity.HasOne(mc => mc.Movie)
                  .WithMany(m => m.MovieCrew)
                  .HasForeignKey(m => m.Movie_id);

            entity.HasOne(mc => mc.Person)
                  .WithMany(p => p.MovieCrew)
                  .HasForeignKey(p => p.Person_id);

            entity.HasOne(mc => mc.Department)
                  .WithMany(d => d.MovieCrew)
                  .HasForeignKey(d => d.Department_id);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable("Department");

            entity.HasKey(d => d.Department_id);

            entity.HasMany(d => d.MovieCrew)
                  .WithOne(mc => mc.Department)
                  .HasForeignKey(d => d.Department_id);
        });

        modelBuilder.Entity<Production_Country>(entity =>
        {
            entity.ToTable("Production_Country");

            entity.HasKey(pc => new { pc.Movie_id, pc.Country_id });

            entity.HasOne(pc => pc.Movie)
                  .WithMany(m => m.ProductionCountry)
                  .HasForeignKey(m => m.Movie_id);

            entity.HasOne(pc => pc.Countrie)
                  .WithMany(c => c.ProductionCountry)
                  .HasForeignKey(c => c.Country_id);
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("Country");

            entity.HasKey(c => c.Country_id);

            entity.HasMany(c => c.ProductionCountry)
                  .WithOne(pc => pc.Countrie)
                  .HasForeignKey(c => c.Country_id);
        });

        modelBuilder.Entity<Movie_Languages>(entity =>
        {
            entity.ToTable("Movie_Languages");

            entity.HasKey(ml => new { ml.Movie_id, ml.Language_id, ml.Language_Role_id });

            entity.HasOne(ml => ml.Movie)
                  .WithMany(m => m.MovieLanguages)
                  .HasForeignKey(m => m.Movie_id);

            entity.HasOne(ml => ml.Language)
                  .WithMany(l => l.MovieLanguages)
                  .HasForeignKey(l => l.Language_id);

            entity.HasOne(ml => ml.LanguageRole)
                  .WithMany(lr => lr.MovieLanguages)
                  .HasForeignKey(ml => ml.Language_Role_id);;
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.ToTable("Language");

            entity.HasKey(l => l.Language_id);

            entity.HasMany(l => l.MovieLanguages)
                  .WithOne(ml => ml.Language)
                  .HasForeignKey(l => l.Language_id);
        });

        modelBuilder.Entity<Language_Role>(entity =>
        {
            entity.ToTable("Language_Role");

            entity.HasKey(lr => lr.Role_id);

            entity.HasMany(lr => lr.MovieLanguages)
                  .WithOne(ml => ml.LanguageRole)
                  .HasForeignKey(ml => ml.Language_Role_id);
        });

        modelBuilder.Entity<Movie_Genre>(entity =>
        {
            entity.ToTable("Movie_Genre");

            entity.HasKey(mg => new { mg.Movie_id, mg.Genre_id });

            entity.HasOne(mg => mg.Movie)
                  .WithMany(m => m.MovieGenre)
                  .HasForeignKey(m => m.Movie_id);

            entity.HasOne(mg => mg.Genre)
                  .WithMany(g => g.MovieGenre)
                  .HasForeignKey(g => g.Genre_id);
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.ToTable("Genre");

            entity.HasKey(g => g.Genre_id);

            entity.HasMany(g => g.MovieGenre)
                  .WithOne(mg => mg.Genre)
                  .HasForeignKey(g => g.Genre_id);
        });

        modelBuilder.Entity<Movie_Keywords>(entity =>
        {
            entity.ToTable("Movie_Keywords");

            entity.HasKey(mk => new { mk.Movie_Id, mk.Keyword_Id });

            entity.HasOne(mk => mk.Movie)
                  .WithMany(m => m.MovieKeywords)
                  .HasForeignKey(m => m.Movie_Id);

            entity.HasOne(mk => mk.Keyword)
                  .WithMany(k => k.MovieKeywords)
                  .HasForeignKey(k => k.Keyword_Id);
        });

        modelBuilder.Entity<Keyword>(entity =>
        {
            entity.ToTable("Keyword");

            entity.HasKey(k => k.Keyword_id);

            entity.HasMany(k => k.MovieKeywords)
                  .WithOne(mk => mk.Keyword)
                  .HasForeignKey(k => k.Keyword_Id);
        });
    }
}
