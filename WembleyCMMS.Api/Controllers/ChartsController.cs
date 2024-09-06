using WembleyCMMS.Api.Application.Queries.Charts;

namespace WembleyCMMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChartsController : ApiControllerBase
    {
        public ChartsController(IMediator mediator) : base(mediator) 
        { 
        }

        [HttpGet]
        public async Task<ChartViewModel>  GetChart([FromQuery]ChartsQuery query)
        {
            return await _mediator.Send(query);
        }
    }
}
