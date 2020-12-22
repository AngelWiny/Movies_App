using System;
using System.Collections.Generic;
using System.Text;

namespace Movies_Totaltech_test.Models
{
    public class Person
    {
        public int id { get; set; }
        public bool adult { get; set; }
        public int gender { get; set; }
        public string known_for_department { get; set; }
        public string name { get; set; }
        public string original_name { get; set; }
        public float popularity { get; set; }
        public string profile_path { get; set; }
        public string credit_id { get; set; }
    }
}
