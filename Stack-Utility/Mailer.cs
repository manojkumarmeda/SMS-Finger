using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using ActiveUp.Net.Mail;

namespace Syntizen.Utilities.Email
{
    public class Mailer
    {
        public static void SendMail(string MailMsg, List<string> MailTo, List<string> MailCc, List<string> MailBcc, string Subject, byte[] Attachment, string AttachmentExt)
        {
            try
            {
                //Smtp Settings
                string mailhost = ConfigurationManager.AppSettings["Host"];

                string mailusername = ConfigurationManager.AppSettings["MailUserName"];
                string mailpassword = ConfigurationManager.AppSettings["MailPassword"];
                string mailport = ConfigurationManager.AppSettings["MailPort"];
                string enablessl = ConfigurationManager.AppSettings["EnableSsl"];

                //Mail Settings
                string mailfrom = ConfigurationManager.AppSettings["MailFromAddress"];
                ActiveUp.Net.Mail.Message message = new ActiveUp.Net.Mail.Message();
                message.From = new Address(mailfrom);
                foreach (string mailto in MailTo) message.To.Add(mailto, "");
                foreach (string mailcc in MailCc) message.Cc.Add(mailcc, "");
                foreach (string mailbcc in MailBcc) message.Bcc.Add(mailbcc, "");
                message.Subject = Subject;

                message.BodyHtml.Text = MailMsg;

                if (Attachment != null)
                {
                    MimePart m = new MimePart(Attachment, AttachmentExt);
                    message.Attachments.Add(m);
                }

                int port = 25;
                // System.Net.ServicePointManager.Expect100Continue = false;
                if (!Int32.TryParse(mailport, out port)) port = 25;

                SmtpClient.SendSsl(message, mailhost, port, mailusername, mailpassword, SaslMechanism.Login);



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}