using DreamOrbit.Greetings.Component.Interface;
using DreamOrbit.Greetings.Data.Context;
using DreamOrbit.Greetings.Data.Interface;
using DreamOrbit.Greetings.Data.Models;
using DreamOrbit.Greetings.EmailBodyComponent.Interface;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamOrbit.Greetings.Component.GreetingsComponent
{
    public class GreetingsComponent : IGreetingsComponent
    {
        private readonly IGreetingsDbRepository _greetingDbRepository;
        private readonly IEmailComponent _emailComponent;
     

        public GreetingsComponent(IGreetingsDbRepository greetingDbRepository,IEmailComponent emailComponent)
        {
            _greetingDbRepository = greetingDbRepository;
            _emailComponent = emailComponent;
          
        }
        public async Task<bool> ProcessBirthdayEmail()
        {
            var employees = await _greetingDbRepository.FetchTodayBirthdayEmployee();

            // fetch smtp server detail
            var smtpDetail = await _greetingDbRepository.FetchSmtpDetail();

            // fetch random birthday wish and images
            var emailmessage = await _greetingDbRepository.FetchEmailMessage();

            foreach (var employee in employees)
            {
                // Prepare email body for each loop.
                var email = await _emailComponent.PrepareEmail(employee,emailmessage);


                // Send email.
                var result =await _emailComponent.SendEmail(smtpDetail, email);

            }
            return true;
        }

        
       public async Task<Employee> GetDreamorbitEmployeeById(int id)
        {
            var data = await _greetingDbRepository.GetDreamorbitEmployeeById(id);
            if(data == null)
            {
                throw new Exception("Invalid ID");
            }
            return data;
        }

        
        public async Task<Employee> AddDreamorbitEmployee(Employee employee)
        {
            await _greetingDbRepository.AddDreamorbitEmployee(employee);
            return employee;

        }

        
        public async Task<bool> UpdatedEmployee(int id,Employee employee)
        {
            return await _greetingDbRepository.UpdatedDreamorbitEmployeeDb(id, employee);
        }

        
        public async Task<Employee> DeleteEmployee(int id)
        {
            return await _greetingDbRepository.DeleteEmployeeFromDb(id);
        }

       

    }
}
