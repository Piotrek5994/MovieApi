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
                name: "Country",
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
                    table.PrimaryKey("PK_Country", x => x.Country_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Department_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Department_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Department_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Gender_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    gender = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Gender_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Genre_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Genre_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Genre_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Keyword",
                columns: table => new
                {
                    Keyword_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Keyword_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keyword", x => x.Keyword_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Language",
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
                    table.PrimaryKey("PK_Language", x => x.Language_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Language_Role",
                columns: table => new
                {
                    Role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Language_role = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language_Role", x => x.Role_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Movie_User",
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
                    table.PrimaryKey("PK_Movie_User", x => x.User_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Person_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Person_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Person_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Production_Company",
                columns: table => new
                {
                    Company_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Company_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Production_Company", x => x.Company_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Movie_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                    table.PrimaryKey("PK_Movie", x => x.Movie_id);
                    table.ForeignKey(
                        name: "FK_Movie_Movie_User_User_id",
                        column: x => x.User_id,
                        principalTable: "Movie_User",
                        principalColumn: "User_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Movie_Cast",
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
                    table.PrimaryKey("PK_Movie_Cast", x => new { x.Movie_id, x.Gender_id, x.Person_id });
                    table.ForeignKey(
                        name: "FK_Movie_Cast_Gender_Gender_id",
                        column: x => x.Gender_id,
                        principalTable: "Gender",
                        principalColumn: "Gender_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movie_Cast_Movie_Movie_id",
                        column: x => x.Movie_id,
                        principalTable: "Movie",
                        principalColumn: "Movie_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movie_Cast_Person_Person_id",
                        column: x => x.Person_id,
                        principalTable: "Person",
                        principalColumn: "Person_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Movie_Company",
                columns: table => new
                {
                    Movie_id = table.Column<int>(type: "int", nullable: false),
                    Company_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie_Company", x => new { x.Movie_id, x.Company_id });
                    table.ForeignKey(
                        name: "FK_Movie_Company_Movie_Movie_id",
                        column: x => x.Movie_id,
                        principalTable: "Movie",
                        principalColumn: "Movie_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movie_Company_Production_Company_Company_id",
                        column: x => x.Company_id,
                        principalTable: "Production_Company",
                        principalColumn: "Company_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Movie_Crew",
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
                    table.PrimaryKey("PK_Movie_Crew", x => new { x.Person_id, x.Movie_id, x.Department_id });
                    table.ForeignKey(
                        name: "FK_Movie_Crew_Department_Department_id",
                        column: x => x.Department_id,
                        principalTable: "Department",
                        principalColumn: "Department_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movie_Crew_Movie_Movie_id",
                        column: x => x.Movie_id,
                        principalTable: "Movie",
                        principalColumn: "Movie_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movie_Crew_Person_Person_id",
                        column: x => x.Person_id,
                        principalTable: "Person",
                        principalColumn: "Person_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Movie_Genre",
                columns: table => new
                {
                    Movie_id = table.Column<int>(type: "int", nullable: false),
                    Genre_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie_Genre", x => new { x.Movie_id, x.Genre_id });
                    table.ForeignKey(
                        name: "FK_Movie_Genre_Genre_Genre_id",
                        column: x => x.Genre_id,
                        principalTable: "Genre",
                        principalColumn: "Genre_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movie_Genre_Movie_Movie_id",
                        column: x => x.Movie_id,
                        principalTable: "Movie",
                        principalColumn: "Movie_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Movie_Keywords",
                columns: table => new
                {
                    Movie_Id = table.Column<int>(type: "int", nullable: false),
                    Keyword_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie_Keywords", x => new { x.Movie_Id, x.Keyword_Id });
                    table.ForeignKey(
                        name: "FK_Movie_Keywords_Keyword_Keyword_Id",
                        column: x => x.Keyword_Id,
                        principalTable: "Keyword",
                        principalColumn: "Keyword_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movie_Keywords_Movie_Movie_Id",
                        column: x => x.Movie_Id,
                        principalTable: "Movie",
                        principalColumn: "Movie_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Movie_Languages",
                columns: table => new
                {
                    Movie_id = table.Column<int>(type: "int", nullable: false),
                    Language_id = table.Column<int>(type: "int", nullable: false),
                    Language_Role_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie_Languages", x => new { x.Movie_id, x.Language_id, x.Language_Role_id });
                    table.ForeignKey(
                        name: "FK_Movie_Languages_Language_Language_id",
                        column: x => x.Language_id,
                        principalTable: "Language",
                        principalColumn: "Language_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movie_Languages_Language_Role_Language_Role_id",
                        column: x => x.Language_Role_id,
                        principalTable: "Language_Role",
                        principalColumn: "Role_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movie_Languages_Movie_Movie_id",
                        column: x => x.Movie_id,
                        principalTable: "Movie",
                        principalColumn: "Movie_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Production_Country",
                columns: table => new
                {
                    Movie_id = table.Column<int>(type: "int", nullable: false),
                    Country_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Production_Country", x => new { x.Movie_id, x.Country_id });
                    table.ForeignKey(
                        name: "FK_Production_Country_Country_Country_id",
                        column: x => x.Country_id,
                        principalTable: "Country",
                        principalColumn: "Country_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Production_Country_Movie_Movie_id",
                        column: x => x.Movie_id,
                        principalTable: "Movie",
                        principalColumn: "Movie_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_User_id",
                table: "Movie",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Cast_Gender_id",
                table: "Movie_Cast",
                column: "Gender_id");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Cast_Person_id",
                table: "Movie_Cast",
                column: "Person_id");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Company_Company_id",
                table: "Movie_Company",
                column: "Company_id");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Crew_Department_id",
                table: "Movie_Crew",
                column: "Department_id");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Crew_Movie_id",
                table: "Movie_Crew",
                column: "Movie_id");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Genre_Genre_id",
                table: "Movie_Genre",
                column: "Genre_id");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Keywords_Keyword_Id",
                table: "Movie_Keywords",
                column: "Keyword_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Languages_Language_id",
                table: "Movie_Languages",
                column: "Language_id");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Languages_Language_Role_id",
                table: "Movie_Languages",
                column: "Language_Role_id");

            migrationBuilder.CreateIndex(
                name: "IX_Production_Country_Country_id",
                table: "Production_Country",
                column: "Country_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movie_Cast");

            migrationBuilder.DropTable(
                name: "Movie_Company");

            migrationBuilder.DropTable(
                name: "Movie_Crew");

            migrationBuilder.DropTable(
                name: "Movie_Genre");

            migrationBuilder.DropTable(
                name: "Movie_Keywords");

            migrationBuilder.DropTable(
                name: "Movie_Languages");

            migrationBuilder.DropTable(
                name: "Production_Country");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "Production_Company");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Keyword");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "Language_Role");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "Movie_User");
        }
    }
}
