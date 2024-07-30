using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Model.Models
{
    public class MailSenderDTO
    {
        public string Header { get; set; }

        public string Body { get; set; }

        public string Subject { get; set; }

        public string Signature { get; set; }
    }
}
