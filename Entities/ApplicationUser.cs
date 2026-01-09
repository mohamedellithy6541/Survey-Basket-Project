using Microsoft.AspNetCore.Identity;
using SurveyBasket.Entities;

namespace SurveyBasket.Api.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; } = [];
    }
}
