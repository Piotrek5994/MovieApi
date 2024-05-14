using System.Text.Json.Serialization;

namespace Core.Model;

public class Movie
{
    public int Movie_id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int Budget { get; set; }
    public string Homepage { get; set; } = string.Empty;
    public string Overview { get; set; } = string.Empty;
    public decimal Popularity { get; set; }
    public string Release_date { get; set; } = string.Empty;
    public string Revenue { get; set; } = string.Empty;
    public int Runtime { get; set; }
    public string Movie_status { get; set; } = string.Empty;
    public string Tagline { get; set; } = string.Empty;
    public decimal Vote_average { get; set; }
    public int Vote_count { get; set; }
    public string Movie_src_foto { get; set; } = string.Empty;
    public string Movie_src_video { get; set; } = string.Empty;
    public int User_id { get; set; }
    public Movie_User? User { get; set; }
    public List<Movie_Company>? MovieCompany { get; set; }
    public List<Movie_Cast>? MovieCast { get; set; }
    public List<Movie_Crew>? MovieCrew { get; set; }
    public List<Production_Country>? ProductionCountry { get; set; }
    public List<Movie_Languages>? MovieLanguages { get; set; }
    public List<Movie_Genre>? MovieGenre { get; set; }
    public List<Movie_Keywords>? MovieKeywords { get; set; }
}