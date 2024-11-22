using ASEC_ContractManagementSystem_API.Data;
using ASEC_ContractManagementSystem_API.Entities;
using ASEC_ContractManagementSystem_API.Models.ViewModels;
using Azure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ASEC_ContractManagementSystem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ApplicationDbContext _db;
        public LoginController(
            IConfiguration config,
            ApplicationDbContext db)
        {
            _config = config;
            _db = db;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserModel login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);
            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                //response = Ok(new { token = tokenString });
                response = Ok(tokenString);
            }
            return response;
        }

        private UserApp AuthenticateUser(UserModel login)
        {
            UserApp user = new UserApp();
            if(login.Username!=null && login.Password != null)
            {
                var authenticateUser = _db.UserApps.Where(x=>x.Username==login.Username && x.Password == login.Password).FirstOrDefault();
                return authenticateUser;
            }
            return user;
        }
        private string GenerateJSONWebToken(UserApp userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Sid, userInfo.UserId.ToString()),

                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var token = new JwtSecurityToken(
         _config["Jwt:Issuer"],   // Ensure this is consistent
         _config["Jwt:Audience"], // Ensure this is consistent
         claims,
         expires: DateTime.Now.AddMinutes(120),
         signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("JwtToken");
            HttpContext.Session.Clear();
            HttpContext.SignOutAsync();
            //return Ok();
            return View("Login");
        }
    }
}
