
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
            return Ok(_pollService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var poll = _pollService.GetById(id);

            return poll is null ? NotFound() : Ok(poll);
        }
        [HttpPost]
        public IActionResult Add(Poll poll)
        {
            var addedpoll = _pollService.AddPoll(poll);
            return CreatedAtAction(nameof(GetById), new { id = addedpoll.id }, addedpoll);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Poll poll)
        {
            var isUpdated = _pollService.upadate(id, poll);

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
