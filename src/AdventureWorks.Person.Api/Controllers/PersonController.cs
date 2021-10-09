using AdventureWorks.Person.Domain.Commands.Person;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AdventureWorks.Person.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IMediator _mediator;

        public PersonController(ILogger<PersonController> logger, IMediator mediator)
        {
            this._logger = logger;
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogDebug("Calling the method {method}", nameof(GetAll));

            var result = await _mediator.Send(new PersonQuery(true, string.Empty));

            _logger.LogInformation("Result on execution {@result}", result);

            return Ok(result);
        }

        [HttpGet("{firstName}/complete")]
        public async Task<IActionResult> GetComplete(string firstName)
        {
            _logger.LogDebug("Calling the method {method} with filter {filter}", nameof(GetComplete), firstName);

            var result = await _mediator.Send(new PersonQuery(false, firstName));

            _logger.LogInformation("Result on execution {@result}", result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePersonCommand person)
        {
            _logger.LogDebug("Calling the method {method} with body {@body}", nameof(Create), person);

            var result = await _mediator.Send(person);

            _logger.LogInformation("Result on execution {@result}", result);

            return Ok(result);
        }
    }
}
