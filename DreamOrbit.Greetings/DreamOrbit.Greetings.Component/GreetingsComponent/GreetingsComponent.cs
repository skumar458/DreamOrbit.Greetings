using DreamOrbit.Greetings.Component.Interface;
using DreamOrbit.Greetings.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamOrbit.Greetings.Component.GreetingsComponent
{
    public class GreetingsComponent : IGreetingsComponent
    {
        private readonly IGreetingsDbRepository _dbRepository;

        public GreetingsComponent(IGreetingsDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public bool ProcessBirthdayEmail()
        {
            return true;
        }
    }
}
