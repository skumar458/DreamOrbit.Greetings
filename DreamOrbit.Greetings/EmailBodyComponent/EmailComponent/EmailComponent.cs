﻿using DreamOrbit.Greetings.EmailBodyComponent.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;                                 //shubham
using System.Text;
using System.Threading.Tasks;
using DreamOrbit.Greetings.Data.Models;
using System.Reflection;
using Stubble.Core.Builders;

namespace DreamOrbit.Greetings.EmailBodyComponent.EmailBodyComponent
{
    public class EmailComponent : IEmailComponent
    {
        private readonly string birthdayTemplate = "DreamOrbit.Greetings.EmailComponent.Resources.BirthdayTemplate.BirthdayEmailTemplate";


        public Email PrepareEmail(Employee employee, List<EmailMessage> emailMessage)
        {
            var singleEmailMessage = GetRandomMessageAndPhoto(emailMessage);

            Email email = new Email();
            email.Subject = "Happy Birthday " + employee.FullName;
            email.To = employee.EmailAddress;
            email.CC = "";
            email.Body = PrepareEmailBody(employee.FullName,singleEmailMessage.Wish,singleEmailMessage.Photo);
            
            return email;
        }

        private EmailMessage GetRandomMessageAndPhoto(List<EmailMessage> emailMessage)
        {
            return emailMessage.FirstOrDefault();

        }

        private string PrepareEmailBody(string FullName, string Wish, string Photo)
        {
            var templateVariable = new
            {
                empname = FullName,
                birthdaywish = Wish,
                birthdayphoto = Photo
            };

            var htmlTemplate = ReadTemplateFromResource(birthdayTemplate);
            return EmailBodyBuilder.GenerateHtmlBody(htmlTemplate, templateVariable);
        }

        private static string ReadTemplateFromResource(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string template;
            using (Stream? stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader? reader = new StreamReader(stream))
            {
                template = reader.ReadToEnd();
            }
            return template;
        }

        public bool SendEmail(MailSmtpDetail mailSmtpDetail, Email request)
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

        public static class EmailBodyBuilder
        {
            public static string GenerateHtmlBody(string htmlTemplate, object templateVariable)
            {
                StubbleBuilder builder = new StubbleBuilder();
                var boundTemplate = builder.Build().Render(htmlTemplate,templateVariable);
                return boundTemplate;
            }
        }

    }
}
