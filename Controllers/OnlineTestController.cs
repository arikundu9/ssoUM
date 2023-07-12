using Microsoft.AspNetCore.Mvc;

namespace ssoUM.Controllers;

[ApiController]
[Route("[controller]")]
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
