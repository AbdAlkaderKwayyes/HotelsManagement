using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthenticationController(IConfiguration configutation)
        {
            _configuration = configutation;
        }

        [HttpPost]
        public ActionResult<AuthRequest> Authenticate(AuthRequest request)
        {
            bool validateUser = ValidateUserInformation(request.Username, request.Password);

            if (!validateUser)
                return Unauthorized();

            var secretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Authentication:SecretKey"]));

            var signingCred = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                new List<Claim> { },
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(10),
                signingCred
            );

            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return Ok(token);
        }

        private bool ValidateUserInformation(string username , string password)
        {
            return username == _configuration["User:username"] &&
                    password == _configuration["User:password"];
        }
    }
}
