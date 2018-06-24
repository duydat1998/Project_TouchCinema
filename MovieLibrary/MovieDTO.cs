using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary
{
    public class MovieDTO
    {
        public string MovieID { get; set; }
        public string MovieTitle { get; set; }
        public int Length { get; set; }
        public float Rating { get; set; }
        public DateTime StartDate { get; set; }
        public string Poster { get; set; }
        public string LinkTrailer { get; set; }
        public string Producer { get; set; }
        public int Year { get; set; }
    }
}
