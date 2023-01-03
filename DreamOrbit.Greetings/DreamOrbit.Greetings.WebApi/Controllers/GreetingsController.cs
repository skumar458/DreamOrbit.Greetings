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
        public async Task<IActionResult> ProcessBirthdayEmail()
        {
            return Ok(await _greetingcomponent.ProcessBirthdayEmail());
        }

  


        [HttpGet("{id}")]
        public async Task<IActionResult> GetDreamorbitEmployeeById(int id) 
        {
            if (id == 0)
            {
                return NotFound();
            }
            return Ok(await _greetingcomponent.GetDreamorbitEmployeeById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddDreamorbitEmployee(Employee employee)
        {
            return Ok(await _greetingcomponent.AddDreamorbitEmployee(employee));

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatedEmployee(int id,Employee employee)
        {
            return Ok(await _greetingcomponent.UpdatedEmployee(id,employee));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            return Ok(await _greetingcomponent.DeleteEmployee(id));
        }
    }
}
