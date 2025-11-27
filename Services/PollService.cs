using Microsoft.EntityFrameworkCore;

namespace SurveyBasket.Api.Services
{
    public class PollService(IMapper mapper, ApplicationContext Context) : IPollService
    {


        #region private Field
        private readonly IMapper _mapper = mapper;
        private readonly ApplicationContext _context = Context;
        #endregion
        public async Task<List<PollResponse>> GetAll()
        {
            var polls = await _context.Polls
                .AsNoTracking()
                .ToListAsync();

            var response = polls.Adapt<List<PollResponse>>();

            return response;
        }
        public async Task<PollResponse> AddPoll(PollRequest request, CancellationToken cancellationToken)
        {
            var poll = request.Adapt<Poll>();
            await _context.Polls.AddAsync(poll, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            var pollResponse = request.Adapt<PollResponse>();
            return pollResponse;
        }
        public async Task<PollResponse> Get(int id, CancellationToken cancellationToken)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero.");

            var poll = await _context.Polls
                      .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (poll is null)
                return null;

            return poll.Adapt<PollResponse>();
        }
        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero.");

            var poll = await _context.Polls
                      .FindAsync(id, cancellationToken);

            if (poll is null) return false;
            _context.Polls.Remove(poll);
            await _context.SaveChangesAsync(cancellationToken);

            return true;

        }

        public async Task<bool> Update(int id, PollRequest createPollRequest, CancellationToken cancellationToken)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero.");

            var poll = await _context.Polls.FindAsync(id, cancellationToken);

            if (poll is null) return false;

            var updatePoll = createPollRequest.Adapt(poll);

            var updatedPoll = _context.Polls.Update(updatePoll);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<bool> ToggelPublish(int id, CancellationToken cancellationToken = default)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero.");

            var poll = await _context.Polls
                      .FindAsync(id, cancellationToken);

            if (poll is null) return false;

            poll.IsPublished = !poll.IsPublished;
            _context.Polls.Update(poll);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
