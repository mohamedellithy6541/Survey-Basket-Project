namespace SurveyBasket.Api.Contracts
{
    public record PollRequest(
        int Id,
        string? Title , 
        string? Description
    );
 
}
