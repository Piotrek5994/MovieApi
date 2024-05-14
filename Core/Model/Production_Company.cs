using System.Text.Json.Serialization;

namespace Core.Model;

public class Production_Company
{
    public int Company_id { get; set; }
    public string Company_name { get; set; } = string.Empty;
    public List<Movie_Company>? MovieCompany { get; set; }
}
