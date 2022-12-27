using DreamOrbit.Greetings.Component.Interface;
using DreamOrbit.Greetings.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DreamOrbit.Greetings.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreetingsController : ControllerBase
    {
        private readonly IGreetingsComponent _greetingcomponent;

        public GreetingsController(IGreetingsComponent greetingcomponent)
        {
            _greetingcomponent = greetingcomponent;
        }

        [HttpGet]
        public IActionResult ProcessBirthdayEmail()
        {
            return Ok(_greetingcomponent.ProcessBirthdayEmail());
        }

        [HttpGet("{id}")]
        public IActionResult GetDreamorbitEmployeeById(int id) 
        {
            if (id == 0)
            {
                return NotFound();
            }
            return Ok(_greetingcomponent.GetDreamorbitEmployeeById(id));
        }

        [HttpPost]
        public IActionResult AddDreamorbitEmployee(Employee employee)
        {
            return Ok(_greetingcomponent.AddDreamorbitEmployee(employee));

        }

        [HttpPut("{id}")]
        public IActionResult UpdatedEmployee(int id,Employee employee)
        {
            return Ok(_greetingcomponent.UpdatedEmployee(id,employee));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            return Ok(_greetingcomponent.DeleteEmployee(id));
        }
    }
}
