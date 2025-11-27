using System.Threading;

namespace SurveyBasket.Api.Services
{
    public interface IPollService
    {
        Task<List<PollResponse>>GetAll();
        Task<PollResponse>AddPoll(PollRequest request, CancellationToken cancellationToken=default);
        Task<PollResponse>Get(int id, CancellationToken cancellationToken = default);
        Task<bool> Delete(int id, CancellationToken cancellationToken = default);
        Task<bool> ToggelPublish(int id, CancellationToken cancellationToken = default);
        Task<bool> Update(int id, PollRequest PollRequest, CancellationToken cancellationToken = default);
    }
}
