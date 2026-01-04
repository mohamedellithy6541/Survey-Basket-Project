namespace SurveyBasket.Api.Authentication
{
    public interface IJwtProvider
    {
        (string token, int expiresIn) GenerateJwtToken(ApplicationUser applicationUser);
    }
}
