using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model;

public class Department
{
    public int Department_id { get; set; }
    public string Department_name { get; set; }
    public Movie_Crew MovieCrew { get; set; }
}
