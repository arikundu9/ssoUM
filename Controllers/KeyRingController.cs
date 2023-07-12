using Microsoft.AspNetCore.Mvc;

namespace ssoUM.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class KeyRingController : ControllerBase
{
    private readonly ILogger<KeyRingController> _logger;

    public KeyRingController(ILogger<KeyRingController> logger)
    {
        _logger = logger;
    }

    [MapToApiVersion("1.0")]
    [HttpGet]
    public string Get()
    {
        return "Online";
    }
    [HttpPost]
    public string Post()
    {
        return "Online";
    }
    [HttpPut]
    public string Put()
    {
        return "Online";
    }
    [HttpDelete]
    public string Delete()
    {
        return "Online";
    }
}
