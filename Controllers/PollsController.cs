
using Mapster;
using MapsterMapper;
using SurveyBasket.Api.Contracts;

namespace SurveyBasket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollsController(IPollService pollService, IMapper mapper) : ControllerBase
    {
        #region property
        private readonly IPollService _pollService = pollService;
        private readonly IMapper _mapper = mapper;
        #endregion

        #region End Points

        [HttpGet("polls")]
        public async Task<ActionResult<List<PollResponse>>> GetAll()
        {
            var polls = await _pollService.GetAll();
            var response = polls.Adapt<List<PollResponse>>();
            return Ok(response);
        }

        [HttpPost("Polls")]
        public async Task<ActionResult<PollResponse>> Add([FromBody] PollRequest poll, CancellationToken cancellationToken)
        {
            var addedpoll = await _pollService.AddPoll(poll, cancellationToken);

            return Ok(addedpoll);
        }
        [HttpGet("{Id}:int")]
        public async Task<ActionResult<PollResponse>> get([FromRoute] int Id, CancellationToken cancellationToken)
        {
            var pollResponse = await _pollService.Get(Id, cancellationToken);
            if (pollResponse is null)
                return NotFound();
            return Ok(pollResponse);
        }
        [HttpDelete("{Id}:int")]
        public async Task<IActionResult> Delete([FromRoute] int Id, CancellationToken cancellationToken)
        {
            var deleted = await _pollService.Delete(Id, cancellationToken);

            if (!deleted)
                return NotFound(); //404

            return NoContent();
        }
        [HttpPut("{Id}:int")]
        public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] PollRequest request, CancellationToken cancellationToken)
        {
            var updated = await _pollService.Update(Id,request, cancellationToken);

            if (!updated)
                return NotFound(); //404

            return NoContent();
        }


        #endregion
    }

}
