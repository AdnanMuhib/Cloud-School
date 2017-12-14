using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloudSchool.Models
{
    public class Student:Person
    {
        [DisplayName("Last Passed Exam")]
        public string LastPassedExam { get; set; }
        [DisplayName("Last Exam Total Marks")]
        public int LastExamTotalMarks { get; set; }
        [DisplayName("Last Exam Obtained Marks")]
        public string LastExamObtainedMarks { get; set; }
        [DisplayName("Registration Number")]
        public String RegistrationNumber { get; set; }
        [DisplayName("Enrolled Class Name")]
        public IEnumerable<ClassForStudents> EnrolledClassName { get; set; }
        [DisplayName("Enrolled Section Name")]
        public string EnrolledSectionName { get; set; }
        [DisplayName("Parents Email ID")]
        public String EmailIDParents { get; set; }
        [DisplayName("List of Course Subjects Read By the Student")]
        public List<CourseSubject> Subjects { get; set; }
        [DisplayName("Profile Picture")]
        [DataType(DataType.ImageUrl)]
        public String ProfilePicture { get; set; }
        // School ID as a foreign key
        [HiddenInput(DisplayValue = false)]
        public string SchoolID { get; set; }
        [Required]
        [HiddenInput(DisplayValue = false)]
        public int CourseID { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int SectionID { get; set; }

    }
}