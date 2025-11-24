namespace SurveyBasket.Api.Contracts
{
    public record CreatePollRequest(
        int Id,
        string? Title , 
        string? Description
    );
 
}
