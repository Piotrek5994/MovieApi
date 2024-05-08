using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model;

public class Movie_Crew
{
    public int Movie_id { get; set; }
    public int Person_id { get; set; }
    public int Department_id { get; set; }
    public string Job { get; set; }
    public List<Movie> Movie { get; set; }
    public List<Person> Persons { get; set; }
    public List<Department> Departments { get; set;}
}
