using SurveyBasket.Api.Contracts.Authorization.Response;

namespace SurveyBasket.Api.Services
{
    public interface IAuthService
    {
        Task<AuthResponse?> GetTokenAync(string email, string password, CancellationToken cancellationToken);
    }
}
