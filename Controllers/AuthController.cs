using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ssoUM.Controllers
{
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiController]
	[ApiVersion("2.10")]
	public class AuthController : ControllerBase
	{
		public IConfiguration Configuration { get; }
		public AuthController(IConfiguration configuration)
		{
			Configuration = configuration;
		}
		[HttpGet("Login")]
		[AllowAnonymous]
		public IActionResult Login()
		{
			try
			{
				var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
				//token = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYmYiOjE2ODI0ODQyMjQsImV4cCI6MTY4MjU3MDYyNCwiaWF0IjoxNjgyNDg0MjI0fQ.QwrkFyUe9rbM77TcMgWCIHvn50C-9K2tA30Nv4lRb3O8DJQaqxNX3j5Fie1dyzBt1t9zT9wdnViOOwMXxP9EVg";
				JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
				JwtSecurityToken jwtToken = tokenHandler.ReadJwtToken(token);

				tokenHandler.ValidateToken(token, GetValidationParameters(), out SecurityToken validatedToken);
				Console.WriteLine("Token validation succeeded.");
				//JwtSecurityTokenHandler tokenHandler  = handler.ReadJwtToken(token.ToString());
				return Ok(new
				{
					status = "ValidToken"
				}); ;
			}
			catch (Exception ex)
			{
				return BadRequest(new { success = false, msg = ex.Message.ToString() });
			}
		}

		private TokenValidationParameters GetValidationParameters()
		{
			TokenValidationParameters validationParameters = new TokenValidationParameters
			{
				ValidateIssuer = false,
				// ValidIssuer = "myIssuer", // replace with your own issuer
				ValidateAudience = false,
				//ValidAudience = "myAudience", // replace with your own audience
				ValidateLifetime = true,
				ClockSkew = TimeSpan.Zero,
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("AppSettings:JWTKey").Value))
			};
			return validationParameters;
		}
	}
}
