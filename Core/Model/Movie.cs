using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model;

public class Movie
{
    public int Movie_id { get; set; }
    public string Title { get; set; }
    public int Budget { get; set; }
    public string Homepage { get; set; }
    public string Overview { get; set; }
    public decimal Popularity { get; set; }
    public string Release_date { get; set; }
    public string Revenue { get; set; }
    public int Runtime { get; set; }
    public string Movie_status { get; set; }
    public string Tagline { get; set; }
    public decimal Vote_average { get; set; }
    public int Vote_count { get; set; }
    public string Movie_src_foto { get; set; }
    public string Movie_src_video { get; set; }
    public int User_id { get; set; }
    public Movie_User User { get; set; }
    public Movie_Company MovieCompany { get; set; }
    public Movie_Cast MovieCast { get; set; }
    public Movie_Crew MovieCrew { get; set; }
}