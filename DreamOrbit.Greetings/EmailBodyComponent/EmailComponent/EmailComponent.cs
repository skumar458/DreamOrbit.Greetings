using DreamOrbit.Greetings.EmailBodyComponent.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamOrbit.Greetings.EmailBodyComponent.EmailBodyComponent
{
    public class EmailComponent : IEmailComponent
    {
        public bool PrepareEmail()
        {
            return true;
        }
        public bool SendEmail()
        {
            return true;
        }

    }
}
