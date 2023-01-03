using DreamOrbit.Greetings.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DreamOrbit.Greetings.EmailBodyComponent.Interface
{
    public interface IEmailComponent
    {
        public Task<Email> PrepareEmail(Employee employee,List<EmailMessage> emailMessage);
        public Task<bool> SendEmail(MailSmtpDetail mailSmtpDetail,Email request);
        


    }
}
