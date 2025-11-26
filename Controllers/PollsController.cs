
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
        public async Task<ActionResult<PollResponse>>Add([FromBody]CreatePollRequest poll)
        {
            var addedpoll = await _pollService.AddPoll(poll);

            return Ok(addedpoll);
        }

        #endregion
    }

}
