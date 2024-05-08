namespace Core.Model;

public class Movie_Keywords
{
    public int Movie_Id { get; set; }
    public int Keyword_Id { get; set; }
    public List<Movie> Movies { get; set; }
    public List<Keyword> Keywords { get; set; }
}
