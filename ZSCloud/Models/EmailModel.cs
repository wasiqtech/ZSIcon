using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZSCloud.Models
{
    public class SendEmailModel
    {
        public int id { get; set; }
        public string Subject { get; set; }
        public string SenderEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Body { get; set; }

    }
}