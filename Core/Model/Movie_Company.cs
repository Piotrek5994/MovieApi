using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model;

public class Movie_Company
{
    public int Movie_id { get; set; } //FK
    public int Company_id { get; set; } //FK
    public List<Production_Company> ProductionCompany { get; set; }
    public List<Movie> Movies { get; set; }
}
