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
        public bool PrepareEmail();
        public bool SendEmail(MailSmtpDetail mailSmtpDetail);


    }
}
