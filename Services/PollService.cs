
using MapsterMapper;
using Microsoft.AspNetCore.Http.HttpResults;

namespace SurveyBasket.Api.Services
{
    public class PollService : IPollService
    {
        public PollService(IMapper mapper)
        {
            _mapper = mapper;
        }
        private readonly List<Poll> _polls =
        [
            new Poll()
            {
                Id = 1,
                Title = "Mohamed",
                Description = "software engineer :)"
            }
        ];
        private readonly IMapper _mapper;

        public Poll AddPoll(PollRequest poll)
        {
            var mappingPoll = _mapper.Map<Poll>(poll);
            mappingPoll.Id = _polls.Count + 1;
            _polls.Add(mappingPoll);
            return mappingPoll;
        }

        public bool Delete(int id)
        {
            var currentPoll = GetById(id);

            if (currentPoll is null) return false;

            var deletedPoll = _polls.SingleOrDefault(x => x.Id == id);

            return _polls.Remove(deletedPoll);
        }

        public IEnumerable<Poll> GetAll() => _polls;
        public Poll? GetById(int id) => _polls.SingleOrDefault(x => x.Id == id);

        public bool Update(int id, Poll poll)
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
