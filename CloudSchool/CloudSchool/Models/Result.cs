using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CloudSchool.Models
{
    public class Result
    {
        public List<CourseSubject> Subjects { get; set; }
        public Double Percentage { get; set; }
        [DisplayName("Result of Registration Number")]
        public String RegistrationNumber { get; set; }

    }
}