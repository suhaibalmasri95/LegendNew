using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
       /* private readonly IConfiguration configuration;
        public AuthController( IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        */
       /* public IActionResult Login([FromBody] Auth auth)
        {
            // Call Sp var user = await repo.Login(auth.Email.ToLower(), auth.Password);
            //if (userDtoLogin == null)
            //  return Unauthorized();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration.GetSection("AppSettings:Token").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                 new Claim(ClaimTypes.NameIdentifier,user.ID.ToString()),
                  new Claim(ClaimTypes.Name ,user.Email)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);


            return Ok(new { tokenString, user });
        }*/
    }
}