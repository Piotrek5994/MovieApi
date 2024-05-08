namespace Core.Model;

public class Production_Country
{
    public int Movie_id { get; set; }
    public int Country_id { get; set; }
    public Movie? Movie { get; set; }
    public Country? Countrie { get; set; }
}
