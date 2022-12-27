using DreamOrbit.Greetings.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamOrbit.Greetings.Component.Interface
{
    public interface IGreetingsComponent
    {
        public bool ProcessBirthdayEmail();
        public Employee GetDreamorbitEmployeeById(int id);
        public Employee AddDreamorbitEmployee(Employee employee);
        public Employee UpdatedEmployee(int id, Employee employee);
        public Employee DeleteEmployee(int id);
    }
}
