using DreamOrbit.Greetings.Component.Interface;
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
    }
}
