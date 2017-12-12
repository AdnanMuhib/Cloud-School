using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloudSchool.Models
{
    public class Result
    {
        public int ID { get; set; }
        public List<CourseSubject> Subjects { get; set; }
        public Double Percentage { get; set; }
        [DisplayName("Result of Registration Number")]
        public String RegistrationNumber { get; set; }
        // School ID as a foreign key
        [HiddenInput(DisplayValue = false)]
        public string SchoolID { get; set; }
        //// Class ID as a foreign key
        //[HiddenInput(DisplayValue = false)]
        //public string ClassID { get; set; }
        //// Class ID as a foreign key
        //[HiddenInput(DisplayValue = false)]
        //public string CourseID { get; set; }

    }
}