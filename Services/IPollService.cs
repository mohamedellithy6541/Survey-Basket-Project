namespace SurveyBasket.Api.Services
{
    public interface IPollService
    {
        Task<List<PollResponse>> GetAll();
        Task<PollResponse> AddPoll(CreatePollRequest request);
        
        
   


    }
}
