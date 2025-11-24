
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

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var polls = _pollService.GetAll();
            var response = polls.Adapt<PollResponse>();
            return Ok(response);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var poll = _pollService.GetById(id);

            var response = poll.Adapt<PollResponse>();

            return response is null ? NotFound() : Ok(response);
        }
        [HttpPost]
        public IActionResult Add(CreatePollRequest poll)
        {
            var addedpoll = _pollService.AddPoll(poll);
            return CreatedAtAction(nameof(Get), new { id = addedpoll.Id }, addedpoll);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CreatePollRequest request)
        {
            var isUpdated = _pollService.Update(id, request.Adapt<Poll>());

            if (!isUpdated) NotFound();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var isDeleted = _pollService.Delete(id);

            if (!isDeleted)
                return NotFound();
         
            return NoContent();

        }


        [HttpPost("Test")]
        public IActionResult Test([FromBody] Poll poll) 
        {
            return Ok("value Accepted");
        }
    }
}
