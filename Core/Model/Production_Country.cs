namespace Core.Model;

public class Production_Country
{
    public int Movie_id { get; set; }
    public int Country_id { get; set; }
    public List<Movie>? Movies { get; set; }
    public List<Country>? Countries { get; set; }
}
