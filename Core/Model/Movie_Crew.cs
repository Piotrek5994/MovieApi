namespace Core.Model;

public class Movie_Crew
{
    public int Movie_id { get; set; }
    public int Person_id { get; set; }
    public int Department_id { get; set; }
    public string Job { get; set; } = string.Empty;
    public Movie? Movie { get; set; }
    public Person? Person { get; set; }
    public Department? Department { get; set; }
}
