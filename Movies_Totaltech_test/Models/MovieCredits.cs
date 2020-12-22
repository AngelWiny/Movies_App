using System;
using System.Collections.Generic;
using System.Text;

namespace Movies_Totaltech_test.Models
{
    public class MovieCredits
    {
        public int id { get; set; }
        public IEnumerable<PersonCast> cast { get; set; }
        public IEnumerable<PersonCrew> crew { get; set; }
    }
}
