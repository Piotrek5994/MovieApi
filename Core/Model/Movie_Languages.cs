namespace Core.Model;

public class Movie_Languages
{
    public int Movie_id { get; set; }
    public int Language_id { get; set; }
    public int Language_Role_id { get; set; }
    public Movie? Movies { get; set; }
    public Language? Languages { get; set; }
    public Language_Role? LanguageRoles { get; set; }
}
