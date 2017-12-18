using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CloudSchool.Models
{
    public class SentMail
    {

        [Key]
        [Required]
        public int MailId { get; set; }

        [Required]
        public int MailRecipientId { get; set; }

        [Required]
        public string SentToMail { get; set; }

        [Required]
        public string SentFromMail { get; set; }

        [Required]
        public System.DateTime SentDate { get; set; }

        public virtual MailRecipient Recipient { get; set; }
    }
}