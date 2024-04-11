using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Services.Implementations;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {        
        private readonly ILogger<PersonController> _logger;
        private Services.Implementations.IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, Services.Implementations.IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personService.FindByID(id);
            if(person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }
        
        [HttpPost()]
        public IActionResult Post([FromBody] Model.Person person)
        {
            if(person == null)
            {
                return BadRequest();
            }
            return Ok(_personService.Create(person));
        } 
        
        [HttpPut()]
        public IActionResult Put([FromBody] Model.Person person)
        {
            if(person == null)
            {
                return BadRequest();
            }
            return Ok(_personService.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personService.Delete(id);            
            return NoContent();
        }

    }
  
}
