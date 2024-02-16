using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using ssoUM.BAL.Interface;
using ssoUM.DTOs;
using ssoUM.Utils;

namespace ssoUM.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
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
        public async Task<ActionResult<RestResponse<bool>>> Post(AppInsertDto app)
        {
            RestResponse<bool> Resp = new();
            try
            {
                Resp.Data = await _appService.Insert(app);
                return Ok(Resp);
            }
            catch (Exception ex)
            {
                return BadRequest(Resp.ErrMsg($"generic error message : {((ex.InnerException != null) ? ex.InnerException.Message : ex.Message)}"));
            }
        }

        // [HttpGet]
        // public IQueryable<App> GetApps(){

        // }
    }
}
