using ssoUM.Authentication;
using ssoUM.DAL.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ssoUM.Middlewares
{

	public class AuthTokenMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly IConfiguration _Configuration;
		private readonly ILogger<AuthTokenMiddleware> _logger;
		private readonly ITokenHelper _tokenHelper;
		public AuthTokenMiddleware(RequestDelegate next, ILogger<AuthTokenMiddleware> logger,
			IConfiguration Configuration, ITokenHelper tokenHelper)
		{
			_next = next;
			_Configuration = Configuration;
			_logger = logger;
			_tokenHelper = tokenHelper;
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

				if (token != null)
				{
					var RefreshedAccessTokenRecieved = false;
					var authClaimModel = _tokenHelper.ValidateAndGetTokenClaims(token, out RefreshedAccessTokenRecieved);
					if (authClaimModel != null)
					{
						context.Items["userclaimmodel"] = authClaimModel;
						if (RefreshedAccessTokenRecieved)
							context.Items["RefreshedAccessTokenRecieved"] = true;
						await _next(context);
					}
					else
					{
						throw new Exception("ErrorMessages.Invalid_token");
					}
				}
				else
				{
					//not required to authenticate
					await _next(context);
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				if (ex.Message == "ErrorMessages.Invalid_token")
				{
					context.Response.StatusCode = StatusCodes.Status401Unauthorized;
					await context.Response.WriteAsync("ErrorMessages.UnAuthenticated");
				}
				else
				{
					context.Response.StatusCode = StatusCodes.Status401Unauthorized;
					await context.Response.WriteAsync("{ \"msg\":\"Error: Incorrect_creden or " + ex.ToString() + "\"}");
				}

			}
		}

	}
	public static class AuthTokenMiddlewareExtensions
	{
		public static IApplicationBuilder UseAuthTokenMiddleware(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<AuthTokenMiddleware>();
		}
	}
}
