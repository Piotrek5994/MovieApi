namespace Core.Model;

public class Movie_Genre
{
    public int Movie_id { get; set; }
    public int Genre_id { get; set; }
    public List<Movie> Movies { get; set; }
    public List<Genre> Genres { get; set; }
}
