using DreamOrbit.Greetings.Data.Context;
using DreamOrbit.Greetings.Data.Interface;
using DreamOrbit.Greetings.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamOrbit.Greetings.Data.GreetingsDbRepository
{
    public class GreetingsDbRepository : IGreetingsDbRepository
    {
        private GreetingsContext _context;

        public GreetingsDbRepository(GreetingsContext context)
        {
            _context = context;
        }
        public List<Employee> FetchTodayBirthdayEmployee()
        {
            return _context.employees.ToList();
        }

    }
}
