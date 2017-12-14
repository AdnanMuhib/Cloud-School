using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloudSchool.Models
{
    public class ClassSection
    {
        public int ID { get; set; }
        [DisplayName("Section Title")]
        public string SectionTitle { get; set; }
        [DisplayName("Section for the Class")]
        public string ClassName { set; get; }
        [DisplayName("From Registration Number")]
        public string StartingRegistrationNumber { set; get; }
        [DisplayName("To Registration Number")]
        public string EndingRegistrationNumber { set; get; }
        [DisplayName("List of Students in The Section")]
        public List<Student> Students { get; set; }
        // School ID as a foreign key
        [HiddenInput(DisplayValue = false)]
        public string SchoolID { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int CourseID { get; set; }
    }
}