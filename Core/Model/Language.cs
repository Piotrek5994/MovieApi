namespace Core.Model;

public class Language
{
    public int Language_id { get; set; }
    public string Language_code { get; set; }
    public string Language_name { get; set; }
    public Movie_Languages MovieLanguages { get; set; }
}
