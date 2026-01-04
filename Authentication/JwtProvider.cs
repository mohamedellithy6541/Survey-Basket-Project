
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SurveyBasket.Api.Authentication
{
    public class JwtProvider : IJwtProvider
    {
        public (string token, int expiresIn) GenerateJwtToken(ApplicationUser user)
        {
            // add clainms
            Claim[] claims = [
                new(JwtRegisteredClaimNames.Sub,user.Id),
                new(JwtRegisteredClaimNames.Email,user.Email!),
                new(JwtRegisteredClaimNames.GivenName,user.FirstName!),
                new(JwtRegisteredClaimNames.FamilyName,user.LastName!),
                new(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            ];

            //Key 
            var symmetricSecuirtiyKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("f844c97f267ceb6e94eed9afb8124e2e1c3f56ee294fcf5e7b8faa6849f3b707"));
            //Credentials
            var singinngCredentials = new SigningCredentials(symmetricSecuirtiyKey, SecurityAlgorithms.HmacSha256);
            // ExpiresIN
            var expiresIn = 30;
            var expiresInDate = DateTime.UtcNow.AddMinutes(expiresIn);
            // token 
            var token = new JwtSecurityToken
             (
                issuer: "SurvayBasketApp",
                audience: "SurvayBasketApp Users",
                claims: claims,
                expires: expiresInDate,
                signingCredentials: singinngCredentials
             );

            return (token: new JwtSecurityTokenHandler().WriteToken(token), expiresIn: expiresIn);
        }
    }
}
