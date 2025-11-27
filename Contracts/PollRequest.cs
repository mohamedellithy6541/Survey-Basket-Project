namespace SurveyBasket.Api.Contracts
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
