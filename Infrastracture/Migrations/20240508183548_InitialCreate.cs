using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    Country_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Country_iso_code = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Country_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.Country_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    Department_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Department_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.Department_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "genders",
                columns: table => new
                {
                    Gender_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    gender = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genders", x => x.Gender_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "genres",
                columns: table => new
                {
                    Genre_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Genre_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genres", x => x.Genre_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "keywords",
                columns: table => new
                {
                    Keyword_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Keyword_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_keywords", x => x.Keyword_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "languages",
                columns: table => new
                {
                    Language_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Language_code = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Language_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_languages", x => x.Language_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "languagesRoles",
                columns: table => new
                {
                    Role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Language_role = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_languagesRoles", x => x.Role_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "persons",
                columns: table => new
                {
                    Person_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Person_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persons", x => x.Person_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "productionCompanies",
                columns: table => new
                {
                    Company_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Company_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productionCompanies", x => x.Company_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    User_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    User_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    User_last_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    User_email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    User_password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    User_phone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    User_role = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.User_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "movies",
                columns: table => new
                {
                    Movie_id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Budget = table.Column<int>(type: "int", nullable: false),
                    Homepage = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Overview = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Popularity = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Release_date = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Revenue = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Runtime = table.Column<int>(type: "int", nullable: false),
                    Movie_status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tagline = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Vote_average = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Vote_count = table.Column<int>(type: "int", nullable: false),
                    Movie_src_foto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Movie_src_video = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    User_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies", x => x.Movie_id);
                    table.ForeignKey(
                        name: "FK_movies_users_Movie_id",
                        column: x => x.Movie_id,
                        principalTable: "users",
                        principalColumn: "User_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "movieCasts",
                columns: table => new
                {
                    Movie_id = table.Column<int>(type: "int", nullable: false),
                    Person_id = table.Column<int>(type: "int", nullable: false),
                    Gender_id = table.Column<int>(type: "int", nullable: false),
                    Character_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cast_order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movieCasts", x => new { x.Movie_id, x.Gender_id, x.Person_id });
                    table.ForeignKey(
                        name: "FK_movieCasts_genders_Gender_id",
                        column: x => x.Gender_id,
                        principalTable: "genders",
                        principalColumn: "Gender_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movieCasts_movies_Movie_id",
                        column: x => x.Movie_id,
                        principalTable: "movies",
                        principalColumn: "Movie_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movieCasts_persons_Person_id",
                        column: x => x.Person_id,
                        principalTable: "persons",
                        principalColumn: "Person_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "movieCompanies",
                columns: table => new
                {
                    Movie_id = table.Column<int>(type: "int", nullable: false),
                    Company_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movieCompanies", x => new { x.Movie_id, x.Company_id });
                    table.ForeignKey(
                        name: "FK_movieCompanies_movies_Movie_id",
                        column: x => x.Movie_id,
                        principalTable: "movies",
                        principalColumn: "Movie_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movieCompanies_productionCompanies_Company_id",
                        column: x => x.Company_id,
                        principalTable: "productionCompanies",
                        principalColumn: "Company_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "movieCrews",
                columns: table => new
                {
                    Movie_id = table.Column<int>(type: "int", nullable: false),
                    Person_id = table.Column<int>(type: "int", nullable: false),
                    Department_id = table.Column<int>(type: "int", nullable: false),
                    Job = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movieCrews", x => new { x.Person_id, x.Movie_id, x.Department_id });
                    table.ForeignKey(
                        name: "FK_movieCrews_departments_Department_id",
                        column: x => x.Department_id,
                        principalTable: "departments",
                        principalColumn: "Department_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movieCrews_movies_Movie_id",
                        column: x => x.Movie_id,
                        principalTable: "movies",
                        principalColumn: "Movie_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movieCrews_persons_Person_id",
                        column: x => x.Person_id,
                        principalTable: "persons",
                        principalColumn: "Person_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "movieGenres",
                columns: table => new
                {
                    Movie_id = table.Column<int>(type: "int", nullable: false),
                    Genre_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movieGenres", x => new { x.Movie_id, x.Genre_id });
                    table.ForeignKey(
                        name: "FK_movieGenres_genres_Genre_id",
                        column: x => x.Genre_id,
                        principalTable: "genres",
                        principalColumn: "Genre_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movieGenres_movies_Movie_id",
                        column: x => x.Movie_id,
                        principalTable: "movies",
                        principalColumn: "Movie_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "movieKeywords",
                columns: table => new
                {
                    Movie_Id = table.Column<int>(type: "int", nullable: false),
                    Keyword_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movieKeywords", x => new { x.Movie_Id, x.Keyword_Id });
                    table.ForeignKey(
                        name: "FK_movieKeywords_keywords_Keyword_Id",
                        column: x => x.Keyword_Id,
                        principalTable: "keywords",
                        principalColumn: "Keyword_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movieKeywords_movies_Movie_Id",
                        column: x => x.Movie_Id,
                        principalTable: "movies",
                        principalColumn: "Movie_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "movieLanguages",
                columns: table => new
                {
                    Movie_id = table.Column<int>(type: "int", nullable: false),
                    Language_id = table.Column<int>(type: "int", nullable: false),
                    Language_Role_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movieLanguages", x => new { x.Movie_id, x.Language_id, x.Language_Role_id });
                    table.ForeignKey(
                        name: "FK_movieLanguages_languagesRoles_Language_Role_id",
                        column: x => x.Language_Role_id,
                        principalTable: "languagesRoles",
                        principalColumn: "Role_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movieLanguages_languages_Language_id",
                        column: x => x.Language_id,
                        principalTable: "languages",
                        principalColumn: "Language_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movieLanguages_movies_Movie_id",
                        column: x => x.Movie_id,
                        principalTable: "movies",
                        principalColumn: "Movie_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "productionCountries",
                columns: table => new
                {
                    Movie_id = table.Column<int>(type: "int", nullable: false),
                    Country_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productionCountries", x => new { x.Movie_id, x.Country_id });
                    table.ForeignKey(
                        name: "FK_productionCountries_countries_Country_id",
                        column: x => x.Country_id,
                        principalTable: "countries",
                        principalColumn: "Country_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productionCountries_movies_Movie_id",
                        column: x => x.Movie_id,
                        principalTable: "movies",
                        principalColumn: "Movie_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_movieCasts_Gender_id",
                table: "movieCasts",
                column: "Gender_id");

            migrationBuilder.CreateIndex(
                name: "IX_movieCasts_Person_id",
                table: "movieCasts",
                column: "Person_id");

            migrationBuilder.CreateIndex(
                name: "IX_movieCompanies_Company_id",
                table: "movieCompanies",
                column: "Company_id");

            migrationBuilder.CreateIndex(
                name: "IX_movieCrews_Department_id",
                table: "movieCrews",
                column: "Department_id");

            migrationBuilder.CreateIndex(
                name: "IX_movieCrews_Movie_id",
                table: "movieCrews",
                column: "Movie_id");

            migrationBuilder.CreateIndex(
                name: "IX_movieGenres_Genre_id",
                table: "movieGenres",
                column: "Genre_id");

            migrationBuilder.CreateIndex(
                name: "IX_movieKeywords_Keyword_Id",
                table: "movieKeywords",
                column: "Keyword_Id");

            migrationBuilder.CreateIndex(
                name: "IX_movieLanguages_Language_id",
                table: "movieLanguages",
                column: "Language_id");

            migrationBuilder.CreateIndex(
                name: "IX_movieLanguages_Language_Role_id",
                table: "movieLanguages",
                column: "Language_Role_id");

            migrationBuilder.CreateIndex(
                name: "IX_productionCountries_Country_id",
                table: "productionCountries",
                column: "Country_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movieCasts");

            migrationBuilder.DropTable(
                name: "movieCompanies");

            migrationBuilder.DropTable(
                name: "movieCrews");

            migrationBuilder.DropTable(
                name: "movieGenres");

            migrationBuilder.DropTable(
                name: "movieKeywords");

            migrationBuilder.DropTable(
                name: "movieLanguages");

            migrationBuilder.DropTable(
                name: "productionCountries");

            migrationBuilder.DropTable(
                name: "genders");

            migrationBuilder.DropTable(
                name: "productionCompanies");

            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropTable(
                name: "persons");

            migrationBuilder.DropTable(
                name: "genres");

            migrationBuilder.DropTable(
                name: "keywords");

            migrationBuilder.DropTable(
                name: "languagesRoles");

            migrationBuilder.DropTable(
                name: "languages");

            migrationBuilder.DropTable(
                name: "countries");

            migrationBuilder.DropTable(
                name: "movies");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
