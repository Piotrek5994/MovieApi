using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CommandDto
{
    public class Create_Movie_Dto
    {
        public string Title { get; set; } = string.Empty;
        public int Budget { get; set; }
        public string Homepage { get; set; } = string.Empty;
        public string Overview { get; set; } = string.Empty;
        public decimal Popularity { get; set; }
        public string Release_date { get; set; } = string.Empty;
        public string Revenue { get; set; } = string.Empty;
        public int Runtime { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Tagline { get; set; } = string.Empty;
        public decimal Vote_average { get; set; }
        public int Vote_count { get; set; }
        public int User_id { get; set; }
    }
}
