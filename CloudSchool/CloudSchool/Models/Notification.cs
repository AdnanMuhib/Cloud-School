using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CloudSchool.Models
{
    public class Notification
    {
        public int ID { get; set; }
        [DisplayName("Email ID")]
        public string EmailIDToNotify { get; set; }
        [DisplayName("Subject of Email")]
        public string Subject { get; set; }
        [DisplayName("Email Content")]
        public String ContentToNotify { get; set; }
    }
}