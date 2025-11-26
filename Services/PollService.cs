
using MapsterMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SurveyBasket.Api.Entities;
using SurveyBasket.Api.Presistance;

namespace SurveyBasket.Api.Services
{
    public class PollService(IMapper mapper, ApplicationContext Context) : IPollService
    {
        
       
        #region private Field
        private readonly IMapper _mapper=mapper;
        private readonly ApplicationContext _context=Context;
        #endregion

        public async Task<List<PollResponse>> GetAll()
        {
            var polls = await _context.Polls
                .AsNoTracking()
                .ToListAsync();

            var response = polls.Adapt<List<PollResponse>>();

            return response;
        }

        public async Task<PollResponse> AddPoll(CreatePollRequest request)
        {
            var poll = request.Adapt<Poll>();
            await _context.Polls.AddAsync(poll);
            await _context.SaveChangesAsync();
            var pollResponse = request.Adapt<PollResponse>();
            return pollResponse;
        }

     
    }
}
