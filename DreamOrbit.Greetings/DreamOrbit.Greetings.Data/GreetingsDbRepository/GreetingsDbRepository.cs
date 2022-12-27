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
        private GreetingsContext _greetingContext;

        public GreetingsDbRepository(GreetingsContext greetingContext)
        {
            _greetingContext = greetingContext;
        }
        public List<Employee> FetchTodayBirthdayEmployee()
        {
            var todayBirthday = _greetingContext.employees.Where(
                                                     s => s.DateOfBirth.Month == DateTime.Today.Month &&
                                                     s.DateOfBirth.Day == DateTime.Today.Day).ToList();
            return todayBirthday;
        }


        public Employee GetDreamorbitEmployeeById(int id)
        {
            return _greetingContext.employees.FirstOrDefault(x => x.EmployeeId == id);
        }


        public Employee AddDreamorbitEmployee(Employee employee)
        {
            _greetingContext.employees.Add(employee);
            _greetingContext.SaveChanges();
            return employee;
        }


        public Employee UpdatedDreamorbitEmployeeDb(int id, Employee Updatedemployee)
        {
            var data = _greetingContext.employees.FirstOrDefault(x =>x.EmployeeId == id);
            if(data != null)
            {
                data.FullName = Updatedemployee.FullName;
                data.UpdatedDate = Updatedemployee.UpdatedDate; 
                data.CreatedDate = Updatedemployee.CreatedDate;
                data.DateOfBirth = Updatedemployee.DateOfBirth;
                data.EmailAddress = Updatedemployee.EmailAddress;
                data.DateOfJoining= Updatedemployee.DateOfJoining;
                data.EmployeeId = Updatedemployee.EmployeeId;
                data.AnniversaryDate = Updatedemployee.AnniversaryDate;

                _greetingContext.SaveChanges();
            }

            return Updatedemployee;
        }


        public Employee DeleteEmployeeFromDb(int id)
        {
           var data = _greetingContext.employees.FirstOrDefault(x =>x.EmployeeId == id);
            if(data != null)
            {
                _greetingContext.employees.Remove(data);
                _greetingContext.SaveChanges();
            }
            return data;
        }

    }
}
