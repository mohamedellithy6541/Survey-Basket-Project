namespace SurveyBasket.Api.Contracts
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
