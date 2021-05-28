using AdventureWorks.Person.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdventureWorks.Person.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            this._personRepository = personRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _personRepository.GetAll();

            return Ok(result);
        }

        [HttpGet("{firstName}/complete")]
        public async Task<IActionResult> GetComplete(string firstName)
        {
            var result = await _personRepository.GetCompleteByName(firstName);

            // --

            return Ok(result);
        }
    }
}
