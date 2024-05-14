namespace Core.ModelDto;

public class Movie_Dto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int Budget { get; set; }
    public string Homepage { get; set; } = string.Empty;
    public string Overview { get; set; } = string.Empty;
    public decimal Popularity { get; set; }
    public string Release_date { get; set; } = string.Empty;
    public string Revenue { get; set; } = string.Empty;
    public int Runtime { get; set; }
    public string Status { get; set; } = string.Empty;
    public string Tagline { get; set; } = string.Empty;
    public decimal Vote_average { get; set; }
    public int Vote_count { get; set; }
    public string Src_foto { get; set; } = string.Empty;
    public string Src_video { get; set; } = string.Empty;
    public int User_id { get; set; }
    public List<Movie_Company_Dto>? MovieCompany { get; set; }
}
