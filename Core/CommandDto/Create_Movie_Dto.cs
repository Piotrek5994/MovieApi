using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CommandDto
{
    public class Create_Movie_Dto
    {
        public string Title { get; set; } = string.Empty;
        [Range(1, int.MaxValue, ErrorMessage = "Must be a positive number.")]
        public int Budget { get; set; }
        public string Homepage { get; set; } = string.Empty;
        public string Overview { get; set; } = string.Empty;
        [Range(1, int.MaxValue, ErrorMessage = "Must be a positive number.")]
        public decimal Popularity { get; set; }
        public string Release_date { get; set; } = string.Empty;
        [Range(1, int.MaxValue, ErrorMessage = "Must be a positive number.")]
        public int Revenue { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Must be a positive number.")]
        public int Runtime { get; set; }
        [RegularExpression("^(Released|inProduction)$", ErrorMessage = "Status must be either 'released' or 'in production'.")]
        public string Status { get; set; } = string.Empty;
        public string Tagline { get; set; } = string.Empty;
        public decimal Vote_average { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Must be a positive number.")]
        public int Vote_count { get; set; }
        public int User_id { get; set; }
    }
}
