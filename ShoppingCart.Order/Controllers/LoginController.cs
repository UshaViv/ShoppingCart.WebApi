using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Domain.RequestModels;

namespace ShoppingCart.Controllers
{
    public class LoginController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public LoginController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequestModel model)
        {
            // Validate user credentials (e.g., username and password)
            if (IsValidUser(model.Username, model.Password))
            {
                // Generate JWT token
                var token = _tokenService.GenerateJwtToken(model.Username);

                // Return the token to the client
                return Ok(new { Token = token });
            }

            return Unauthorized(); // Return 401 Unauthorized if credentials are invalid
        }

        private static bool IsValidUser(string username, string password)
        {
            if (username.ToLower() == "usha" && password == "12345")
            {
                return true;
            }

            return false;
        }
    }
}
