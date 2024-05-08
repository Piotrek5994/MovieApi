namespace Core.Model;

public class Language_Role
{
    public int Role_id { get; set; }
    public string Language_role { get; set; } = string.Empty;
    public List<Movie_Languages>? MovieLanguages { get; set; }
}
