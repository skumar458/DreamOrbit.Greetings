using DreamOrbit.Greetings.Component.Interface;
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
        private readonly IEmailComponent emailComponent;

        public GreetingsComponent(IGreetingsDbRepository greetingDbRepository)
        {
            _greetingDbRepository = greetingDbRepository;
        }

        public bool ProcessBirthdayEmail()
        {
            var employees = _greetingDbRepository.FetchTodayBirthdayEmployee();
            foreach (var employee in employees)
            {
                // Prepare email body for each loop.
                emailComponent.PrepareEmail();


                // Send email.
                emailComponent.SendEmail();

            }
            return true;
        }

        
       public Employee GetDreamorbitEmployeeById(int id)
        {
            var data = _greetingDbRepository.GetDreamorbitEmployeeById(id);
            if(data == null)
            {
                throw new Exception("Invalid ID");
            }
            return data;
        }

        
        public Employee AddDreamorbitEmployee(Employee employee)
        {
            _greetingDbRepository.AddDreamorbitEmployee(employee);
            return employee;

        }

        
        public Employee UpdatedEmployee(int id,Employee employee)
        {
            return _greetingDbRepository.UpdatedDreamorbitEmployeeDb(id,employee);
        }

        
        public Employee DeleteEmployee(int id)
        {
            return _greetingDbRepository.DeleteEmployeeFromDb(id);
        }

       

    }
}
