using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using School.DTOs.UserDTO;
using School.Models;
using School.Repo.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace School.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IConfiguration configuration;

        public AuthController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.configuration = configuration;
        }


        [HttpPost]
        public IActionResult Login(LoginDTO dto)
        {
            var user = unitOfWork.userRepo.GetByUserName(dto.UserName);
            if (user == null)
            {
                return Unauthorized("invalid name or password");
            }
            if (user.PasswordHash != dto.PasswordHash)
            {
                return Unauthorized("invalid name or password");
            }

            var token = GenerateToken(user);
            return Ok(token);

            
        }


        private string GenerateToken(User user)
        {
            //payload
            var claim = new List<Claim>
            {
                new Claim (ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Role,user.Role),
            };
            //signature
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwt:key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["jwt:Issuer"],
                audience: configuration["jwt:Audience"],
                claims: claim,
                expires: DateTime.Now.AddHours(1),
                signingCredentials:creds

                );
            return new JwtSecurityTokenHandler().WriteToken(token);


        }
    }
}