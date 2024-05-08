﻿// <auto-generated />
using Infrastracture.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastracture.Migrations
{
    [DbContext(typeof(MySqlDbContext))]
    partial class MySqlDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Core.Model.Country", b =>
                {
                    b.Property<int>("Country_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Country_id"));

                    b.Property<string>("Country_iso_code")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Country_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Country_id");

                    b.ToTable("countries");
                });

            modelBuilder.Entity("Core.Model.Department", b =>
                {
                    b.Property<int>("Department_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Department_id"));

                    b.Property<string>("Department_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Department_id");

                    b.ToTable("departments");
                });

            modelBuilder.Entity("Core.Model.Gender", b =>
                {
                    b.Property<int>("Gender_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Gender_id"));

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Gender_id");

                    b.ToTable("genders");
                });

            modelBuilder.Entity("Core.Model.Genre", b =>
                {
                    b.Property<int>("Genre_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Genre_id"));

                    b.Property<string>("Genre_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Genre_id");

                    b.ToTable("genres");
                });

            modelBuilder.Entity("Core.Model.Keyword", b =>
                {
                    b.Property<int>("Keyword_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Keyword_id"));

                    b.Property<string>("Keyword_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Keyword_id");

                    b.ToTable("keywords");
                });

            modelBuilder.Entity("Core.Model.Language", b =>
                {
                    b.Property<int>("Language_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Language_id"));

                    b.Property<string>("Language_code")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Language_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Language_id");

                    b.ToTable("languages");
                });

            modelBuilder.Entity("Core.Model.Language_Role", b =>
                {
                    b.Property<int>("Role_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Role_id"));

                    b.Property<string>("Language_role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Role_id");

                    b.ToTable("languagesRoles");
                });

            modelBuilder.Entity("Core.Model.Movie", b =>
                {
                    b.Property<int>("Movie_id")
                        .HasColumnType("int");

                    b.Property<int>("Budget")
                        .HasColumnType("int");

                    b.Property<string>("Homepage")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Movie_src_foto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Movie_src_video")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Movie_status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Overview")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Popularity")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Release_date")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Revenue")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Runtime")
                        .HasColumnType("int");

                    b.Property<string>("Tagline")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("User_id")
                        .HasColumnType("int");

                    b.Property<decimal>("Vote_average")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("Vote_count")
                        .HasColumnType("int");

                    b.HasKey("Movie_id");

                    b.ToTable("movies");
                });

            modelBuilder.Entity("Core.Model.Movie_Cast", b =>
                {
                    b.Property<int>("Movie_id")
                        .HasColumnType("int");

                    b.Property<int>("Gender_id")
                        .HasColumnType("int");

                    b.Property<int>("Person_id")
                        .HasColumnType("int");

                    b.Property<int>("Cast_order")
                        .HasColumnType("int");

                    b.Property<string>("Character_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Movie_id", "Gender_id", "Person_id");

                    b.HasIndex("Gender_id");

                    b.HasIndex("Person_id");

                    b.ToTable("movieCasts");
                });

            modelBuilder.Entity("Core.Model.Movie_Company", b =>
                {
                    b.Property<int>("Movie_id")
                        .HasColumnType("int");

                    b.Property<int>("Company_id")
                        .HasColumnType("int");

                    b.HasKey("Movie_id", "Company_id");

                    b.HasIndex("Company_id");

                    b.ToTable("movieCompanies");
                });

            modelBuilder.Entity("Core.Model.Movie_Crew", b =>
                {
                    b.Property<int>("Person_id")
                        .HasColumnType("int");

                    b.Property<int>("Movie_id")
                        .HasColumnType("int");

                    b.Property<int>("Department_id")
                        .HasColumnType("int");

                    b.Property<string>("Job")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Person_id", "Movie_id", "Department_id");

                    b.HasIndex("Department_id");

                    b.HasIndex("Movie_id");

                    b.ToTable("movieCrews");
                });

            modelBuilder.Entity("Core.Model.Movie_Genre", b =>
                {
                    b.Property<int>("Movie_id")
                        .HasColumnType("int");

                    b.Property<int>("Genre_id")
                        .HasColumnType("int");

                    b.HasKey("Movie_id", "Genre_id");

                    b.HasIndex("Genre_id");

                    b.ToTable("movieGenres");
                });

            modelBuilder.Entity("Core.Model.Movie_Keywords", b =>
                {
                    b.Property<int>("Movie_Id")
                        .HasColumnType("int");

                    b.Property<int>("Keyword_Id")
                        .HasColumnType("int");

                    b.HasKey("Movie_Id", "Keyword_Id");

                    b.HasIndex("Keyword_Id");

                    b.ToTable("movieKeywords");
                });

            modelBuilder.Entity("Core.Model.Movie_Languages", b =>
                {
                    b.Property<int>("Movie_id")
                        .HasColumnType("int");

                    b.Property<int>("Language_id")
                        .HasColumnType("int");

                    b.Property<int>("Language_Role_id")
                        .HasColumnType("int");

                    b.HasKey("Movie_id", "Language_id", "Language_Role_id");

                    b.HasIndex("Language_Role_id");

                    b.HasIndex("Language_id");

                    b.ToTable("movieLanguages");
                });

            modelBuilder.Entity("Core.Model.Movie_User", b =>
                {
                    b.Property<int>("User_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("User_id"));

                    b.Property<string>("User_email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("User_last_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("User_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("User_password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("User_phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("User_role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("User_id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Core.Model.Person", b =>
                {
                    b.Property<int>("Person_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Person_id"));

                    b.Property<string>("Person_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Person_id");

                    b.ToTable("persons");
                });

            modelBuilder.Entity("Core.Model.Production_Company", b =>
                {
                    b.Property<int>("Company_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Company_id"));

                    b.Property<string>("Company_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Company_id");

                    b.ToTable("productionCompanies");
                });

            modelBuilder.Entity("Core.Model.Production_Country", b =>
                {
                    b.Property<int>("Movie_id")
                        .HasColumnType("int");

                    b.Property<int>("Country_id")
                        .HasColumnType("int");

                    b.HasKey("Movie_id", "Country_id");

                    b.HasIndex("Country_id");

                    b.ToTable("productionCountries");
                });

            modelBuilder.Entity("Core.Model.Movie", b =>
                {
                    b.HasOne("Core.Model.Movie_User", "User")
                        .WithMany("Movie")
                        .HasForeignKey("Movie_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Model.Movie_Cast", b =>
                {
                    b.HasOne("Core.Model.Gender", "Genders")
                        .WithMany("MovieCast")
                        .HasForeignKey("Gender_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Model.Movie", "Movies")
                        .WithMany("MovieCast")
                        .HasForeignKey("Movie_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Model.Person", "Persons")
                        .WithMany("MovieCast")
                        .HasForeignKey("Person_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genders");

                    b.Navigation("Movies");

                    b.Navigation("Persons");
                });

            modelBuilder.Entity("Core.Model.Movie_Company", b =>
                {
                    b.HasOne("Core.Model.Production_Company", "ProductionCompany")
                        .WithMany("MovieCompany")
                        .HasForeignKey("Company_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Model.Movie", "Movies")
                        .WithMany("MovieCompany")
                        .HasForeignKey("Movie_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movies");

                    b.Navigation("ProductionCompany");
                });

            modelBuilder.Entity("Core.Model.Movie_Crew", b =>
                {
                    b.HasOne("Core.Model.Department", "Departments")
                        .WithMany("MovieCrew")
                        .HasForeignKey("Department_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Model.Movie", "Movie")
                        .WithMany("MovieCrew")
                        .HasForeignKey("Movie_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Model.Person", "Persons")
                        .WithMany("MovieCrew")
                        .HasForeignKey("Person_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departments");

                    b.Navigation("Movie");

                    b.Navigation("Persons");
                });

            modelBuilder.Entity("Core.Model.Movie_Genre", b =>
                {
                    b.HasOne("Core.Model.Genre", "Genres")
                        .WithMany("MovieGenre")
                        .HasForeignKey("Genre_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Model.Movie", "Movies")
                        .WithMany("MovieGenre")
                        .HasForeignKey("Movie_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genres");

                    b.Navigation("Movies");
                });

            modelBuilder.Entity("Core.Model.Movie_Keywords", b =>
                {
                    b.HasOne("Core.Model.Keyword", "Keywords")
                        .WithMany("MovieKeywords")
                        .HasForeignKey("Keyword_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Model.Movie", "Movies")
                        .WithMany("MovieKeywords")
                        .HasForeignKey("Movie_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Keywords");

                    b.Navigation("Movies");
                });

            modelBuilder.Entity("Core.Model.Movie_Languages", b =>
                {
                    b.HasOne("Core.Model.Language_Role", "LanguageRoles")
                        .WithMany("MovieLanguages")
                        .HasForeignKey("Language_Role_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Model.Language", "Languages")
                        .WithMany("MovieLanguages")
                        .HasForeignKey("Language_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Model.Movie", "Movies")
                        .WithMany("MovieLanguages")
                        .HasForeignKey("Movie_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LanguageRoles");

                    b.Navigation("Languages");

                    b.Navigation("Movies");
                });

            modelBuilder.Entity("Core.Model.Production_Country", b =>
                {
                    b.HasOne("Core.Model.Country", "Countries")
                        .WithMany("ProductionCountry")
                        .HasForeignKey("Country_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Model.Movie", "Movies")
                        .WithMany("ProductionCountry")
                        .HasForeignKey("Movie_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Countries");

                    b.Navigation("Movies");
                });

            modelBuilder.Entity("Core.Model.Country", b =>
                {
                    b.Navigation("ProductionCountry");
                });

            modelBuilder.Entity("Core.Model.Department", b =>
                {
                    b.Navigation("MovieCrew");
                });

            modelBuilder.Entity("Core.Model.Gender", b =>
                {
                    b.Navigation("MovieCast");
                });

            modelBuilder.Entity("Core.Model.Genre", b =>
                {
                    b.Navigation("MovieGenre");
                });

            modelBuilder.Entity("Core.Model.Keyword", b =>
                {
                    b.Navigation("MovieKeywords");
                });

            modelBuilder.Entity("Core.Model.Language", b =>
                {
                    b.Navigation("MovieLanguages");
                });

            modelBuilder.Entity("Core.Model.Language_Role", b =>
                {
                    b.Navigation("MovieLanguages");
                });

            modelBuilder.Entity("Core.Model.Movie", b =>
                {
                    b.Navigation("MovieCast");

                    b.Navigation("MovieCompany");

                    b.Navigation("MovieCrew");

                    b.Navigation("MovieGenre");

                    b.Navigation("MovieKeywords");

                    b.Navigation("MovieLanguages");

                    b.Navigation("ProductionCountry");
                });

            modelBuilder.Entity("Core.Model.Movie_User", b =>
                {
                    b.Navigation("Movie");
                });

            modelBuilder.Entity("Core.Model.Person", b =>
                {
                    b.Navigation("MovieCast");

                    b.Navigation("MovieCrew");
                });

            modelBuilder.Entity("Core.Model.Production_Company", b =>
                {
                    b.Navigation("MovieCompany");
                });
#pragma warning restore 612, 618
        }
    }
}
