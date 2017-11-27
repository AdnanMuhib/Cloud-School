using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CloudSchool.Models
{
    public class Feedback
    {
        public int ID { get; set; }
        [DisplayName("Subject of the Feedback")]
        public string Subject { get; set; }
        [DisplayName("Details about the Feedback")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}