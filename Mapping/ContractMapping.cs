
using SurveyBasket.Api.Contract.Request;
using SurveyBasket.Api.Contract.Response;

namespace SurveyBasket.Api.Mapping
{
    public static class ContractMapping
    {
        public static PollResponse MapToPollResponse(this Poll poll)
        {
            return new()
            {
                id = poll.id,
                Title = poll.Title,
                Description = poll.Description,
            };
        }
        public static IEnumerable<PollResponse> MapToPollResponseList(this IEnumerable<Poll> poll)
        {
            return poll.Select(MapToPollResponse);
        }
        public static Poll MapToPoll(this CreatePollRequest poll)
        {
            return new()
            {
                Title = poll.Title,
                Description = poll.Description,
            };
        }
    }
}
