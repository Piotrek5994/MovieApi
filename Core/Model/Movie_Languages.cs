namespace Core.Model;

public class Movie_Languages
{
    public int Movie_id { get; set; }
    public int Language_id { get; set; }
    public int Language_Role_id { get; set; }
    public List<Movie> Movies { get; set; }
    public List<Language> Languages { get; set; }
    public List<Language_Role> LanguageRoles { get; set; }
}
