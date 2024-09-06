using WembleyCMMS.Api.Application.Commands.Persons;
using WembleyCMMS.Api.Application.Queries.Persons;

namespace WembleyCMMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ApiControllerBase
    {
        public PersonsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] CreatePersonCommand command)
        {
            return await CommandAsync(command);
        }

        [HttpGet]
        public async Task<QueryResult<PersonViewModel>> GetPersons([FromQuery] PersonsQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet]
        [Route("{personId}")]
        public async Task<QueryResult<PersonViewModel>> GetPersonById([FromRoute] string personId)
        {
            var query = new PersonByIdQuery(personId);
            return await _mediator.Send(query);
        }

        [HttpPut]
        [Route("{personId}")]
        public async Task<IActionResult> UpdatePerson([FromRoute] string personId, [FromBody] UpdatePersonViewModel person)
        {
            var command = new UpdatePersonCommand(personId, person.PersonName);
            return await CommandAsync(command);
        }

        [HttpDelete]
        [Route("{personId}")]
        public async Task<IActionResult> DeletePerson([FromRoute] string personId)
        {
            var command = new DeletePersonCommand(personId);
            return await CommandAsync(command);
        }
    }
}
