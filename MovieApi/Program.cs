using Core.IRepositories;
using Infrastracture.Db;
using Infrastracture.Repositories;
using Infrastracture.Service;
using Infrastracture.Service.IService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

namespace MovieApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configure logging
        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();
        builder.Logging.SetMinimumLevel(LogLevel.Information);

        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("localDb");
        builder.Services.AddDbContext<MySqlDbContext>(options =>
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        //AutoMapper
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddControllers();

        //Service 
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<ICountryService, CountryService>();
        builder.Services.AddScoped<IDepartmentService, DepartmentService>();
        builder.Services.AddScoped<IGenderService, GenderService>();
        builder.Services.AddScoped<IKeywordService, KeywordService>();
        builder.Services.AddScoped<ILanguageService, LanguageService>();
        builder.Services.AddScoped<ILanguageRoleService, LanguageRoleService>();
        builder.Services.AddScoped<IMovieCastService, MovieCastService>();
        builder.Services.AddScoped<IMovieCompanyService, MovieCompanyService>();
        builder.Services.AddScoped<IMovieService, MovieService>();
        builder.Services.AddScoped<IMovieCrewService , MovieCrewService>();
        builder.Services.AddScoped<IMovieGenreService, MovieGenreService>();
        builder.Services.AddScoped<IMovieKeywordsService, MovieKeywordsService>();
        builder.Services.AddScoped<IMovieLanguagesService, MovieLanguagesService>();
        builder.Services.AddScoped<IPersonService, PersonService>();
        builder.Services.AddScoped<IProductionCompanyService, ProductionCompanyService>();
        builder.Services.AddScoped<IProductionCountryService, ProductionCountryService>();
        builder.Services.AddScoped<IUserService, UserService>();

        //Repository
        builder.Services.AddScoped<IAuthRepositories, AuthRepositories>();
        builder.Services.AddScoped<ICountryRepositories, CountryRepositories>();
        builder.Services.AddScoped<IDepartmentRepositories, DepartmentRepositories>();
        builder.Services.AddScoped<IGenderRepositories, GenderRepositories>();
        builder.Services.AddScoped<IKeywordRepositories, KeywordRepositories>();
        builder.Services.AddScoped<ILanguageRepositories, LanguageRepositories>();
        builder.Services.AddScoped<ILanguageRoleRepositories, LanguageRoleRepositories>();
        builder.Services.AddScoped<IMovieCastRepositories, MovieCastRepositories>();
        builder.Services.AddScoped<IMovieCompanyRepositories, MovieCompanyRepositories>();
        builder.Services.AddScoped<IMovieRepositories, MovieRepositories>();
        builder.Services.AddScoped<IMovieCrewRepositories, MovieCrewRepositories>();
        builder.Services.AddScoped<IMovieGenreRepositories, MovieGenreRepositories>();
        builder.Services.AddScoped<IMovieKeywordsRepositories, MovieKeywordsRepositories>();
        builder.Services.AddScoped<IMovieLanguagesRepositories, MovieLanguagesRepositories>();
        builder.Services.AddScoped<IPersonRepositories, PersonRepositories>();
        builder.Services.AddScoped<IProductionCompanyRepositories, ProductionCompanyRepositories>();
        builder.Services.AddScoped<IProductionCountryRepositories, ProductionCountryRepositories>();
        builder.Services.AddScoped<IUserRepositories, UserRepositories>();

        //Swagger 
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {

            options.MapType<Stream>(() => new OpenApiSchema { Type = "file", Format = "binary" });

            options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
            });

            options.OperationFilter<SecurityRequirementsOperationFilter>();

            //Add access for swagger model example
            options.ExampleFilters();

            options.CustomSchemaIds(type =>
            {
                return type.Name switch
                {
                    _ => type.Name
                };
            });
        });
        

        builder.Services.AddSwaggerExamplesFromAssemblyOf<Program>();

        // Configure JWT authentication for the application.
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateAudience = false,
                ValidateIssuer = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                    builder.Configuration.GetSection("AppSettings:Token").Value!))
            };
            options.Events = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    var token = context.Request.Headers["Authorization"].FirstOrDefault();

                    if (!string.IsNullOrEmpty(token))
                    {
                        if (token.StartsWith("Bearer "))
                        {
                            token = token.Substring("Bearer ".Length);
                        }
                        context.Token = token;
                    }
                    return Task.CompletedTask;
                }
            };
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Movie Api V1");
            });
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
