using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace ssoUM.Controllers;


[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class OnlineTestController : ControllerBase
{
    private readonly ILogger<OnlineTestController> _logger;

    public OnlineTestController(ILogger<OnlineTestController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public string Get()
    {
        return "Online";
    }
}
