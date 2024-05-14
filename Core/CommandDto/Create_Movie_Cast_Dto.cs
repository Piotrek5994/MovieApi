using System.ComponentModel.DataAnnotations;

namespace Core.CommandDto;

public class Create_Movie_Cast_Dto
{
    [Required]
    public int Movie_id { get; set; }
    [Required]
    public int Person_id { get; set; }
    public string Character_name { get; set; } = string.Empty;
    [Required]
    public int Gender_id { get; set; }
    public int Cast_order { get; set; }
}
