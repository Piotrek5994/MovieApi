namespace Core.Model;

public class Movie_Keywords
{
    public int Movie_Id { get; set; }
    public int Keyword_Id { get; set; }
    public Movie? Movie { get; set; }
    public Keyword? Keyword { get; set; }
}
