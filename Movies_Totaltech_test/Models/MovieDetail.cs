using System;
using System.Collections.Generic;
using System.Text;

namespace Movies_Totaltech_test.Models
{
    public class MovieDetail : Movie
    {
        public MovieCollection belongs_to_collection { get; set; }
        public int budget { get; set; }
        public IEnumerable<Genre> genres { get; set; }
        public string homepage { get; set; }
        public string imdb_id { get; set; }
        public IEnumerable<ProductionCompany> production_companies { get; set; }
        public IEnumerable<ProductionCounty> production_countries { get; set; }
        public int revenue { get; set; }
        public int runtime { get; set; }
        public IEnumerable<Language> spoken_languages { get; set; }
        public string status { get; set; }
        public string tagline { get; set; }


    }
}
