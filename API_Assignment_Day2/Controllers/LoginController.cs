using API_Assignment_Day2.Models;
using API_Assignment_Day2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_Assignment_Day2.Controllers
{
    [ApiController]
    [Route("api/logins")]
    public class LoginController : Controller
    {
        private IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        public IActionResult Login(UserRequest userRequest)
        {
            var user = DummyUserData.Users.Find(u => u.UserName == userRequest.UserName && u.Password == userRequest.Password);
            if(user == null)
                return BadRequest("Username or password is not correct");
            var token = GenerateToken(user);
            return Ok(token);
        }

        private string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role)
            };
            var expire = DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["Jwt:ExpireInMinutes"]));
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: expire,
                signingCredentials: creds
                );
            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }
    }
}
