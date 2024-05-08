namespace Core.Model;

public class Movie_Genre
{
    public int Movie_id { get; set; }
    public int Genre_id { get; set; }
    public Movie? Movies { get; set; }
    public Genre? Genres { get; set; }
}
