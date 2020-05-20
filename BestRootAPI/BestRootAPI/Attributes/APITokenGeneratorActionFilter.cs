using Entities;
using Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.FilterModels;
using Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BestRootAPI.Attributes
{
	public class APITokenGeneratorActionFilter : ActionFilterAttribute
	{
		private IConfiguration _configuration { get; set; }

		public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			var myController = context.Controller as IBaseApiController;

			if (myController != null)
			{
				string newToken;

				_configuration = myController.Configuration;
				var user = context.HttpContext.User.Identity;
				if (user != null)
				{
					newToken = await GenerateToken(user);
					context.HttpContext.Session.SetString("Token", newToken);
				}
			}
			await base.OnActionExecutionAsync(context, next);
		}

		private async Task<string> GenerateToken(IIdentity identity)
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, identity.Name),
				new Claim(ClaimTypes.NameIdentifier, identity.GetUserId()),
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
