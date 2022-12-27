using DreamOrbit.Greetings.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamOrbit.Greetings.Data.Interface
{
    public interface IGreetingsDbRepository
    {
        public List<Employee> FetchTodayBirthdayEmployee();
        public Employee GetDreamorbitEmployeeById(int id);
        public Employee AddDreamorbitEmployee(Employee employee);
        public Employee UpdatedDreamorbitEmployeeDb(int id, Employee employee);
        public Employee DeleteEmployeeFromDb(int id);

    }
}
