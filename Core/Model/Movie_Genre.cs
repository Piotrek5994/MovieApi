namespace Core.Model;

public class Movie_Genre
{
    public int Movie_id { get; set; }
    public int Genre_id { get; set; }
    public Movie? Movie { get; set; }
    public Genre? Genre { get; set; }
}
