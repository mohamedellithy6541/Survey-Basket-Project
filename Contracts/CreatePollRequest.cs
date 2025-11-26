namespace SurveyBasket.Api.Contracts
{
    public record CreatePollRequest(
    string? Title,
    string? Notes,
    bool IsPublished,
    DateOnly StartAt,
    DateOnly EndAt,
    DateOnly TimeToPlayTheGame 
);

}
