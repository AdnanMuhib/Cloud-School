using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CloudSchool.Models
{
    public class Person
    {
        public int ID { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Father Name")]
        public string FatherName { get; set; }
        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        [DisplayName("Email ID")]
        public string EmailID { set; get; }
        [DisplayName("ID Card Number")]
        public string CNIC { get; set; }
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Name of Institute")]
        public string InstituteName { set; get; }
        [DisplayName("Home/Postal Address")]
        public string Address { set; get; }
        [DisplayName("Mobile Number")]
        public string MobileNumber { set; get; }
        [DisplayName("Gender")]
        public string Gender { set; get; }

    }
}