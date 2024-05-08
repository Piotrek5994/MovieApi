namespace Core.Model;

public class Language_Role
{
    public int Role_id { get; set; }
    public string Language_role { get; set; }
    public Movie_Languages MovieLanguages { get; set; }
}
