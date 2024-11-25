using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExternalDataReview.Properties;

namespace ExternalDataReview
{
    public class Student
    {
        // Many student properties
        // Major at their university

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // Creating the Major property in the class
        public string Major { get; set; }
    }
}
