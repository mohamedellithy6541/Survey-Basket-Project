namespace SurveyBasket.Api.Services
{
    public interface IPollService
    {
        IEnumerable<Poll?> GetAll();
        Poll GetById(int id );
        Poll AddPoll(Poll request);
        bool Update(int id, Poll poll);
        bool Delete(int id);


    }
}
