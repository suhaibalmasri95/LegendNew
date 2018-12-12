using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Authentication;
using Domain.Entities.Organization;
using Domain.Operations.Organization.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration configuration;
        public AuthController( IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        [Route("Login")]
        [HttpPost]
        public IActionResult Login([FromBody] Auth auth)
        {
            GetUsers loginOperation = new GetUsers();

            if(loginOperation.LangID == null)
            {
                auth.langId = 1;
            }
            var operation = loginOperation.Login(auth).Result;

            var userList = (List<User>)operation;
            if(userList.Count>0)
            {
                var user = userList[0];
        
            
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

            user.Password = "";
            return Ok(new { tokenString, user });
        }
            else
            {
                return Unauthorized();
            }
        }
    }
}