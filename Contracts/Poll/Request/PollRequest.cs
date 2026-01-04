namespace SurveyBasket.Api.Contracts.Poll.Request
{
    public record PollRequest(
    string? Title,
    string? Summery,
    bool IsPublished,
    DateOnly StartAt,
    DateOnly EndAt,
    DateOnly TimeToPlayTheGame 
);

}
