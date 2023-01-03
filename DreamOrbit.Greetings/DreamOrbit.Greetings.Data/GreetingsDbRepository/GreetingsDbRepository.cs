using DreamOrbit.Greetings.Data.Context;
using DreamOrbit.Greetings.Data.Interface;
using DreamOrbit.Greetings.Data.Models;
using Microsoft.EntityFrameworkCore;
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
        public async Task<List<Employee>> FetchTodayBirthdayEmployee()
        {
            var todayBirthday =await _greetingContext.employees.Where(
                                                     s => s.DateOfBirth.Month == DateTime.Today.Month &&
                                                     s.DateOfBirth.Day == DateTime.Today.Day).ToListAsync();
            return todayBirthday;
        }

        public async Task<MailSmtpDetail> FetchSmtpDetail()
        {
            return await _greetingContext.mailSmtpDetails.FirstOrDefaultAsync();
        }

        public async Task<List<EmailMessage>> FetchEmailMessage()
        {
            return await _greetingContext.emailMessage.ToListAsync();
        }


        public async Task<Employee> GetDreamorbitEmployeeById(int id)
        {
            return await _greetingContext.employees.FirstOrDefaultAsync(x => x.EmployeeId == id);
        }


        public async Task<Employee> AddDreamorbitEmployee(Employee employee)
        {
            await _greetingContext.employees.AddAsync(employee);
            await _greetingContext.SaveChangesAsync();
            return  employee;
        }


        public async Task<bool> UpdatedDreamorbitEmployeeDb(int id, Employee Updatedemployee)
        {
            var data = await _greetingContext.employees.FirstOrDefaultAsync(x =>x.EmployeeId == id);
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

                await _greetingContext.SaveChangesAsync();
            }

            return true;
        }


        public async Task<Employee> DeleteEmployeeFromDb(int id)
        {
           var data = await _greetingContext.employees.FirstOrDefaultAsync(x =>x.EmployeeId == id);
            if(data != null)
            {
                _greetingContext.employees.Remove(data);
                await _greetingContext.SaveChangesAsync();
            }
            return data;
        }


    }
}
