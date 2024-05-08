namespace Core.Model;

public class Gender
{
    public int Gender_id { get; set; }
    public string gender { get; set; }
    public Movie_Cast MovieCast { get; set; }
}
