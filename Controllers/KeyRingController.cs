using Microsoft.AspNetCore.Mvc;
using ssoUM.BAL.Interface;

namespace ssoUM.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class KeyRingController : ControllerBase
{
    private readonly ILogger<KeyRingController> _logger;

    public KeyRingController(ILogger<KeyRingController> logger,IKeyService keyService)
    {
        _logger = logger;
    }

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
