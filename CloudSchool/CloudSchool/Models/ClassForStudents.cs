using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloudSchool.Models
{
    public class ClassForStudents
    {
        public int ID { get; set; }
        [DisplayName("Name of the Class")]
        public String Name { get; set; }
        [DisplayName("Year of the Class")]
        public DateTime year { get; set; }
        [DisplayName("List of Students in the Class")]
        public List<Student> Students { get; set; }
        [DisplayName("Number of Sections In the Class")]
        public int NumberOfSections { get; set; }
        [DisplayName("List of Sections in The Class")]
        public List<ClassSection> Sections { get; set; }
        // School ID as a foreign key
        [HiddenInput(DisplayValue = false)]
        public string SchoolID { get; set; }
    }
}