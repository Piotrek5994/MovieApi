namespace Core.Model;

public class Person
{
    public int Person_id { get; set; }
    public string Person_name { get; set; } = string.Empty;
    public Movie_Cast? MovieCast { get; set; }
    public Movie_Crew? MovieCrew { get; set; }
}
