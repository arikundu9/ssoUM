using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace ssoUM.Controllers;


[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.1", Deprecated = true)]
public class OnlineTestController : ControllerBase
{
	private readonly ILogger<OnlineTestController> _logger;

	public OnlineTestController(ILogger<OnlineTestController> logger)
	{
		_logger = logger;
	}

	/// <summary>
	/// Generates string "Online"
	/// </summary>
	/// <remarks>
	/// Generates string "Online"
	/// </remarks>
	/// <returns></returns>
	[HttpGet]
	public string Get()
	{
		return "Online";
	}
}
