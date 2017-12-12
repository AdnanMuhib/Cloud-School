using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloudSchool.Models
{
    public class Teacher:Person
    {
        public string Qualification { get; set; }
        public String Experience { get; set; }
        [DataType(DataType.ImageUrl)]
        public String ProfilePicture { get; set; }
        [DisplayName("Subjects Taught by the Teacher")]
        public List<CourseSubject> subjects { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string SchoolID { get; set; }
    }
}