using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ssoUM.BAL.Interface;
using ssoUM.DAL.Entities;
using ssoUM.Utils;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

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
        public ActionResult<RestResponse<App>> Post()
        {
            RestResponse<App> Resp = new();
            try
            {

                return Ok(Resp);
            }
            catch (Exception ex)
            {
                return BadRequest(Resp.ErrMsg($"generic error message : {ex.Message}"));
            }
        }

        // [HttpGet]
        // public IQueryable<App> GetApps(){

        // }
    }
}
