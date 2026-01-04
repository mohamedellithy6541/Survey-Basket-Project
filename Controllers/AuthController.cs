using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyBasket.Api.Contracts.Authorization.Request;

namespace SurveyBasket.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService)  : ControllerBase
    {
        private readonly IAuthService _authService = authService;
        [HttpPost]
        public async Task<IActionResult>LoginAsync(LoginRequest loginRequest ,CancellationToken cancellationToken)
        {
            var response =await _authService.GetTokenAync(loginRequest.email, loginRequest.password, cancellationToken);
            if (response is null) return BadRequest("Invalid Email Or Password");
            return Ok(response);

        }
    }
}
