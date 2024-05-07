using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model;

public class Person
{
    public int Person_id { get; set; }
    public string Person_name { get; set; }
    public Movie_Cast MovieCast { get; set; }
    public Movie_Crew MovieCrew { get; set; }
}
