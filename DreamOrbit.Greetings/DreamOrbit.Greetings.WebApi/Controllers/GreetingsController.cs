using DreamOrbit.Greetings.Component.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DreamOrbit.Greetings.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreetingsController : ControllerBase
    {
        private readonly IGreetingsComponent _component;

        public GreetingsController(IGreetingsComponent component)
        {
            _component = component;
        }

        [HttpGet]
        public IActionResult ProcessBirthdayEmail()
        {
            return Ok(_component.ProcessBirthdayEmail);
        }
    }
}
