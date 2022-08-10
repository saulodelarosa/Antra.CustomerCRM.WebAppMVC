using CustomerCRM.Core.Contracts.Service;
using CustomerCRM.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CustomerCRMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountServiceAsync accountServiceAsync;
        private readonly IConfiguration configuration;

        public AccountController(IAccountServiceAsync acc, IConfiguration cb)
        {
            accountServiceAsync = acc;
            configuration = cb;   
        }

        [HttpPost]
        [Route("signup")]

        public async Task<IActionResult> SignUpAsync(SignUpModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await accountServiceAsync.SignUpAsync(model);
            if (result.Succeeded)
            {
                return Ok(new { Message = "User has been created successfully" });
            }
            StringBuilder sb = new StringBuilder();
            foreach (var item in result.Errors)
            {
                sb.Append(item.Description);
            }
            return BadRequest(sb.ToString());
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(SignInModel model)
        {
            var result = await accountServiceAsync.LogInAsync(model);

            if (!result.Succeeded)
            {
                return Unauthorized(new {Message="Invalid Username or Password" });
            }

            //list of claims to validate tolken
            var AuthClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, model.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secrete"]));

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: AuthClaims,
                signingCredentials: new SigningCredentials(authKey,SecurityAlgorithms.HmacSha256Signature)
                );

            var t = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new {jwt=t});
        }

    }

}
