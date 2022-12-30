using DreamOrbit.Greetings.EmailBodyComponent.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DreamOrbit.Greetings.Data.Models;

namespace DreamOrbit.Greetings.EmailBodyComponent.EmailBodyComponent
{
    public class EmailComponent : IEmailComponent
    {
       

        public bool PrepareEmail()
        {
            return true;
        }
        public bool SendEmail(MailSmtpDetail mailSmtpDetail)
        {

            string fromMail = mailSmtpDetail.FromMailAddress;
            string fromPassword = mailSmtpDetail.FromPassword;

            MailMessage message = new MailMessage(); 

            message.From = new MailAddress(fromMail);
            message.Subject = "Test Subject";
            message.To.Add(new MailAddress("ashish2017pandey@gmail.com"));
            message.Body = "<html><body> Ashish tu pagal hai!!!  </body></html>";
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient(mailSmtpDetail.ServerName)
            {
                Port = mailSmtpDetail.Port,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = mailSmtpDetail.IsEnableSsl,
            };

            smtpClient.Send(message);

            return true;
        }

    }
}
