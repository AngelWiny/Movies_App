using System;
using System.Collections.Generic;
using System.Text;

namespace Movies_Totaltech_test.Models
{
    public class MoviesPage
    {
        public int page { get; set; }
        public IEnumerable<Movie> results { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
    }
}
