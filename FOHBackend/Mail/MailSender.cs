using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MimeKit;
using MailKit.Net.Smtp;

namespace FOHBackend.Mail {
    public class MailSender {

        public static MailboxAddress getAddress(string name, string addr) {
            return new MailboxAddress(name, addr);
        }

        public static MailboxAddress getAddress(MailAddress addr) {
            return new MailboxAddress(addr.Name, addr.EMail);
        }

        public static void sendBasicMessage(MailboxAddress sender, MailboxAddress recv, string subject, string body) {
            var msg = new MimeMessage();
            msg.From.Add(sender != null ? sender : getAddress(Settingsv2.Active.SenderAddress));
            msg.To.Add(recv);
            msg.ReplyTo.Add(sender != null ? sender : getAddress(Settingsv2.Active.SenderAddress));
            msg.Subject = subject;
            msg.Body = new TextPart("plain") {
                Text = body
            };
            sendMessage(msg);
        }

        public static void sendMessage(MimeMessage msg) {
            using (var client = new SmtpClient()) {
                client.Connect(Settingsv2.Active.SMTP.SMTPServer, Settingsv2.Active.SMTP.SMTPPort, false);
                // client.Connect(Settings.ActiveSettings.SMTP.SMTPServer, Settings.ActiveSettings.SMTP.SMTPPort, false);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                // client.Authenticate(Settings.ActiveSettings.GMailUsername, Settings.ActiveSettings.GMailPassword);
                client.Authenticate(Settingsv2.Active.SMTP.Username, Settingsv2.Active.SMTP.Password);
                client.Send(msg);
                client.Disconnect(true);
            }
        }
    }
}
