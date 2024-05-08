namespace Core.Model;

public class Person
{
    public int Person_id { get; set; }
    public string Person_name { get; set; } = string.Empty;
    public List<Movie_Cast>? MovieCast { get; set; }
    public List<Movie_Crew>? MovieCrew { get; set; }
}
