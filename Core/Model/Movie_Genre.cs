namespace Core.Model;

public class Movie_Genre
{
    public int Movie_id { get; set; }
    public int Genre_id { get; set; }
    List<Movie> Movies { get; set; }
    List<Genre> Genres { get; set; }
}
