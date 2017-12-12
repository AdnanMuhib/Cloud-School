using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloudSchool.Models
{
    public class CourseSubject
    {
        public int ID { get; set; }
        public string SubjectTitle { get; set; }
        public int TotalMarks { get; set; }
        public int ObtainedMarks { get; set; }
        // School ID as a foreign key
        [HiddenInput(DisplayValue = false)]
        public string SchoolID { get; set; }
    }
}