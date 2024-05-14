namespace Core.ModelDto;

public class Movie_Cast_Dto
{
    public int Movie_id { get; set; }
    public int Person_id { get; set; }
    public string Character_name { get; set; } = string.Empty;
    public int Gender_id { get; set; }
    public int Cast_order { get; set; }
}
