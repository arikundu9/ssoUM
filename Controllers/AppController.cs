using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using ssoUM.BAL.Interface;
using ssoUM.DAL.Entities;
using ssoUM.DTOs;
using ssoUM.Utils;

namespace ssoUM.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json", "application/xml")]
    [Consumes("application/json", "application/xml")]
    public class AppController : ControllerBase
    {
        public IConfiguration Configuration { get; }

        private readonly IAppService _appService;

        public AppController(IConfiguration configuration, IAppService appService)
        {
            Configuration = configuration;
            _appService = appService;
        }
        [HttpPost]
        // [Produces("application/json", "application/xml")]
        // [Consumes("application/json", "application/xml")]
        public async Task<ActionResult<RestResponse<long>>> Post(AppInsertDto app)
        {
            RestResponse<long> Resp = new();
            try
            {
                Resp.Data = await _appService.Insert(app);
                Resp.Message = $"Application registered successfully (Application ID: {Resp.Data})";
                return Ok(Resp);
            }
            catch (Exception ex)
            {
                return BadRequest(Resp.ErrMsg($"{((ex.InnerException != null) ? ex.InnerException.Message : ex.Message)}"));
            }
        }

        [HttpGet]
        // [Produces("application/json", "application/xml")]
        // [Consumes("application/json", "application/xml")]
        public async Task<ActionResult<RestResponse<IEnumerable<App>>>> Get()
        {
            RestResponse<IEnumerable<App>> Resp = new();
            try
            {
                Resp.Data = await _appService.getAll();
                return Ok(Resp);
            }
            catch (Exception ex)
            {
                return BadRequest(Resp.ErrMsg($"{((ex.InnerException != null) ? ex.InnerException.Message : ex.Message)}"));
            }
        }

        [HttpGet("getuser")]
        [Produces("application/xml")]
        public IActionResult GetUser(int id)
        {
            var user = new { Id = id, Name = "Steve James" };
            return Ok(user);
        }
    }
}
