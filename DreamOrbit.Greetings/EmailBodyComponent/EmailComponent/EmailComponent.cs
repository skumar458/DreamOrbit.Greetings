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
       

        public async Task<Email> PrepareEmail(Employee employee, List<EmailMessage> emailMessage)
        {

            Email email = new Email();
            email.Subject = "Happy Birthday " + employee.FullName;
            email.To = employee.EmailAddress;
            email.CC = "";
            email.Photo = "";
            email.Body = "";
            return email;
        }
        public async Task<bool> SendEmail(MailSmtpDetail mailSmtpDetail, Email request)
        {

            string fromMail = mailSmtpDetail.FromMailAddress;
            string fromPassword = mailSmtpDetail.FromPassword;

            MailMessage message = new MailMessage(); 

            message.From = new MailAddress(fromMail);
            message.Subject = request.Subject;
            message.To.Add(new MailAddress(request.To));
            message.Body = request.Body;
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
