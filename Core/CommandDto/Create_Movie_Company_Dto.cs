using System.ComponentModel.DataAnnotations;

namespace Core.CommandDto;

public class Create_Movie_Company_Dto
{
    [Required]
    public int Movie_id { get; set; }
    [Required]
    public int Company_id { get; set; }
}
