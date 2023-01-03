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
        public Task<bool> ProcessBirthdayEmail();
        public Task<Employee> GetDreamorbitEmployeeById(int id);
        public Task<Employee> AddDreamorbitEmployee(Employee employee);
        public Task<bool> UpdatedEmployee(int id, Employee employee);
        public Task<Employee> DeleteEmployee(int id);
    }
}
