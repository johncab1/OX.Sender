using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OX.Sender.Entities
{
    public class MailConfiguration
    {
        public string UserValidationTemplate { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public string Password { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Host { get; set; }
    }
}
