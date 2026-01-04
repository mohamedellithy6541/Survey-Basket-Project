namespace SurveyBasket.Api.Contracts.Poll.Response
{
    public record PollResponse(
        int Id,
        string? Title,
        string? Notes, 
        bool IsPublished,
        DateOnly StartAt,
        DateOnly EndAt
    );
    
}
