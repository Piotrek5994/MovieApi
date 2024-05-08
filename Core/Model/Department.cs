namespace Core.Model;

public class Department
{
    public int Department_id { get; set; }
    public string Department_name { get; set; } = string.Empty;
    public List<Movie_Crew>? MovieCrew { get; set; }
}
