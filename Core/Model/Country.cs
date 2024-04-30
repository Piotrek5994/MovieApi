using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model;

public class Country
{
    public int Country_id { get; set; } // PK
    public string Country_iso_code { get; set; }
    public string Country_name { get; set; }
}
