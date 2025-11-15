
using SurveyBasket.Api.Contract.Request;
using SurveyBasket.Api.Mapping;

namespace SurveyBasket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollsController(IPollService pollService) : ControllerBase
    {
        #region property
        private readonly IPollService _pollService = pollService;
        #endregion

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var polls = _pollService.GetAll();
            return Ok(polls.MapToPollResponseList());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var poll = _pollService.GetById(id);

            return poll is null ? base.NotFound() : base.Ok((object)poll.MapToPollResponse());
        }
        [HttpPost]
        public IActionResult Add(CreatePollRequest poll)
        {
            var addedpoll = _pollService.AddPoll(poll.MapToPoll());
            return CreatedAtAction(nameof(GetById), new { id = addedpoll.id }, addedpoll);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CreatePollRequest poll)
        {
            var isUpdated = _pollService.upadate(id, poll.MapToPoll());

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
    }
}
