namespace SurveyBasket.Api.Services
{
    public class PollService : IPollService
    {
        private readonly List<Poll> _polls =
        [

            new Poll()
            {
                id = 1,
                Title = "Mohamed",
                Description = "software engineer :)"
            }
        ];

        public Poll AddPoll(Poll poll)
        {
            poll.id = _polls.Count + 1;
            _polls.Add(poll);
            return poll;
        }

        public bool Delete(int id)
        {
            var currentPoll = GetById(id);

            if (currentPoll is null) return false;

            var deletedpoll = _polls.SingleOrDefault(x => x.id == id);

            return _polls.Remove(deletedpoll);
        }

        public IEnumerable<Poll> GetAll() => _polls;
        public Poll? GetById(int id) => _polls.SingleOrDefault(x => x.id == id);

        public bool upadate(int id, Poll poll)
        {
            var currentpoll = GetById(id);
            if (currentpoll is null)
                return false;
            currentpoll.Title = poll.Title;
            currentpoll.Description = poll.Description;
            return true;
        }
    }
}
