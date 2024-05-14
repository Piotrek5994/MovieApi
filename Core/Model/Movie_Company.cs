using System.Text.Json.Serialization;

namespace Core.Model;

public class Movie_Company
{
    public int Movie_id { get; set; } //FK
    public int Company_id { get; set; } //FK
    public Production_Company? ProductionCompany { get; set; }
    public Movie? Movie { get; set; }
}
