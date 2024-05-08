namespace Core.Model;

public class Production_Country
{
    public int Movie_id { get; set; }
    public int Country_id { get; set; }
    public Movie? Movies { get; set; }
    public Country? Countries { get; set; }
}
