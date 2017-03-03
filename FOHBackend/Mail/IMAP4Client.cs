using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MailKit.Net.Imap;

namespace FOHBackend.Mail {
    public delegate void CMessageReceived(object sender, EventArgs e);

    public class IMAP4Client {

        public event CMessageReceived onMessageReceive;
    }
}
