using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models;

namespace BestRootAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;

        public AccountsController(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterModel registerModel)
        {
            var newUser = new IdentityUser { UserName = registerModel.Email, Email = registerModel.Email };

            var result = await _userManager.CreateAsync(newUser, registerModel.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description);

                return BadRequest(new RegisterResult { Successful = false, Errors = errors });
            }

            return Ok(new RegisterResult { Successful = true });
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginModel loginModel)
        {
            var result = new LoginResult();
            if (await IsValidUsernameAndPassword(loginModel))
            {
                result.Successful = true;
                result.Error = "";
                result.Token = await GenerateToken(loginModel.Email);
                return Ok(result);
            }
            else
            {
                result.Successful = false;
                result.Error = "The e-mail or password does not match";
                result.Token = "";
                return BadRequest(result);
            }
        }

        private async Task<bool> IsValidUsernameAndPassword(LoginModel registerModel)
        {
            var user = await _userManager.FindByEmailAsync(registerModel.Email);
            return await _userManager.CheckPasswordAsync(user, registerModel.Password);
        }

        private async Task<string> GenerateToken(string username)
        {
            var user = await _userManager.FindByEmailAsync(username);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddHours(4)).ToUnixTimeSeconds().ToString()),
            };

            var token = new JwtSecurityToken(
                new JwtHeader(
                    new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"])),
                        SecurityAlgorithms.HmacSha256
                        )
                    ),
                new JwtPayload(claims)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}