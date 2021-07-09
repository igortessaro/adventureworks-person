using AdventureWorks.Person.Domain.Commands.Person;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdventureWorks.Person.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new PersonQuery(true, string.Empty));

            return Ok(result);
        }

        [HttpGet("{firstName}/complete")]
        public async Task<IActionResult> GetComplete(string firstName)
        {
            var result = await _mediator.Send(new PersonQuery(false, firstName));

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePersonCommand person)
        {
            var result = await _mediator.Send(person);

            return Ok(result);
        }
    }
}
