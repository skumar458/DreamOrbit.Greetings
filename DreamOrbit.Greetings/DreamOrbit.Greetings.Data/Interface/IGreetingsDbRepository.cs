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
        public Task<List<Employee>> FetchTodayBirthdayEmployee();
        public Task<Employee> GetDreamorbitEmployeeById(int id);
        public Task<Employee> AddDreamorbitEmployee(Employee employee);
        public Task<bool> UpdatedDreamorbitEmployeeDb(int id, Employee employee);
        public Task<Employee> DeleteEmployeeFromDb(int id);
        public Task<MailSmtpDetail> FetchSmtpDetail();
        public Task<List<EmailMessage>> FetchEmailMessage();
    }
}
