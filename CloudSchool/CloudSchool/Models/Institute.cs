using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CloudSchool.Models
{
    public class Institute
    {
        public int ID { get; set; }
        public String Name { get; set; }
        [DisplayName("Type Of Institute(e.g College, School Academy)")]
        public String TypeOfInstitute { get; set; }
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        [DisplayName("Email ID")]
        public string Email { get; set; }
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Address and Location of the Institution")]
        public string Address { get; set; }
        [DisplayName("List of Subjects Offered")]
        public List<CourseSubject> Subjects { get; set; }
        [DisplayName("List of Enrolled Students")]
        public List<Student> Students { get; set; }
        [DisplayName("List of Hired Teachers")]
        public List<Teacher> Teachers { get; set; }
        [DisplayName("List of Compiled Results")]
        public List<Result> Results { get; set; }
        [DisplayName("List of Programs/Classes")]
        public List<ClassForStudents> Classes { get; set; }
        [DisplayName("List of Sections")]
        public List<ClassSection> Sections { get; set; }
        [DisplayName("List of Feedback/Complaints")]
        public List<Feedback> Complaints { get; set; }
        [DisplayName("Logo of Institute")]
        [DataType(DataType.Upload)]
        public string Logo { get; set; }

    }
}