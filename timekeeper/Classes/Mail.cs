using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net.Mail;

namespace Timekeeper.Classes
{
    public class Mail
    {
        private Classes.Options Options;

        public Mail()
        {
            this.Options = Timekeeper.Options;
        }

        public bool Send(string toAddress, string messageBody)
        {
            try {
                // TODO: Update Settings to use Options
                // TODO: Update Options to handle mail settings

                SmtpClient Client = new SmtpClient(Options.Mail_SmtpServer, Options.Mail_SmtpPort);
                //SmtpClient Client = new SmtpClient("mail.lockshire.net", 26);
                //SmtpClient Client = new SmtpClient("smtp.gmail.com", 587);
                //Client.EnableSsl = true;
                Client.Timeout = Options.Mail_SmtpTimeout * 1000;
                Client.DeliveryMethod = SmtpDeliveryMethod.Network;
                Client.UseDefaultCredentials = false;
                //Client.Credentials = new System.Net.NetworkCredential("hillsc@phizzy.com", "e44@&7740E5@C52$");
                //Client.Credentials = new System.Net.NetworkCredential("celdaran", "mvdajtwkyqcvuqvi");
                Client.Credentials = new System.Net.NetworkCredential(Options.Mail_SmtpServerUsername, Options.Mail_SmtpServerPassword);

                //MailAddress FromAddress = new MailAddress("public@lockshire.net", "Timekeeper Notification");
                //MailAddress ToAddress = new MailAddress("public@lockshire.net", "Charlie Hills"); // Configured on a per-event basis

                MailAddress FromAddress = new MailAddress(Options.Mail_FromAddress, Options.Mail_FromDisplayAddress);
                MailAddress ToAddress = new MailAddress(toAddress, toAddress);
                MailMessage Message = new System.Net.Mail.MailMessage(FromAddress, ToAddress);

                Message.Subject = "Timekeeper Reminder";
                Message.SubjectEncoding = System.Text.Encoding.UTF8;

                // set body-message and encoding
                Message.Body = messageBody;
                Message.Body += String.Format("\n\nThis message connected to {0} and sent from {1} to {2}",
                    Client.Host + ":" + Client.Port.ToString(),
                    FromAddress.DisplayName + " <" + FromAddress.Address + ">",
                    ToAddress.DisplayName + " <" + ToAddress.Address + ">");
                Message.BodyEncoding = System.Text.Encoding.UTF8;
                Message.IsBodyHtml = false;

                Client.Send(Message);

                return true;
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
                Technitivity.Toolbox.Common.Warn("Error sending email\n\n" + x.ToString());
                return false;
            }
        }
    }
}
