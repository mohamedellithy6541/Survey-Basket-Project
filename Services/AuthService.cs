using Microsoft.AspNetCore.Identity;
using SurveyBasket.Api.Contracts.Authorization.Response;

namespace SurveyBasket.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AuthResponse?> GetTokenAync(string email, string password, CancellationToken cancellationToken)
        {
            // check at email 
            var user = await _userManager.FindByEmailAsync(email);

            if (user is null) return null;

            //check password 
            var isValidPassword =  await _userManager.CheckPasswordAsync(user, password);

            if (!isValidPassword) return null;
            // Generate jwt 







            // Retern auth response

            return new AuthResponse( user.Id,user.Email,user.FirstName,user.LastName, "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiYWRtaW4iOnRydWUsImlhdCI6MTUxNjIzOTAyMn0.KMUFsIDTnFmyG3nMiGM6H9FNFUROf3wh7SmqJp-QV30", 3600);
        }
    }
}
