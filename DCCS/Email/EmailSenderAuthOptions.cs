using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCCS.Email
{
    public class EmailSenderAuthOptions
    {
        public string Email_Smtp_Host { get; set; }
        public string Email_Smtp_Port { get; set; }
        public string Email_Sender_User { get; set; }
        public string Email_Sender_Key { get; set; }
    }
}
