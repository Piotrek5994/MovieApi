namespace Core.Model;

public class Movie_Languages
{
    public int Movie_id { get; set; }
    public int Language_id { get; set; }
    public int Language_Role_id { get; set; }
    public Movie? Movie { get; set; }
    public Language? Language { get; set; }
    public Language_Role? LanguageRole { get; set; }
}
