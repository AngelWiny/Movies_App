using System;
using System.Collections.Generic;
using System.Text;

namespace Movies_Totaltech_test.Models
{
    public class PersonCast : Person
    {
        public int cast_id { get; set; }
        public string character { get; set; }
        public int order { get; set; }
    }
}
