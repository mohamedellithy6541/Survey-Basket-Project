namespace SurveyBasket.Api.Contracts.Authorization.Request
{
    public record LoginRequest(
        string email,
        string password 
        );
    
}
