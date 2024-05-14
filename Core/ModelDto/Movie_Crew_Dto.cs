namespace Core.ModelDto;

public class Movie_Crew_Dto
{
    public int Movie_id { get; set; }
    public int Person_id { get; set; }
    public int Department_id { get; set; }
    public string Job { get; set; } = string.Empty;
}
