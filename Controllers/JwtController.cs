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
    public class JwtController : ControllerBase
    {
        public IConfiguration Configuration { get; }

        private readonly IJwtService _JwtService;

        public JwtController(IConfiguration configuration, IJwtService JwtService)
        {
            Configuration = configuration;
            _JwtService = JwtService;
        }
        [HttpPost]
        public async Task<ActionResult<RestResponse<bool>>> Post(JwtInsertDto Jwt)
        {
            RestResponse<bool> Resp = new();
            try
            {
                Resp.Data = await _JwtService.Insert(Jwt);
                return Ok(Resp);
            }
            catch (Exception ex)
            {
                return BadRequest(Resp.ErrMsg($"{((ex.InnerException != null) ? ex.InnerException.Message : ex.Message)}"));
            }
        }

        // [HttpGet]
        // public IQueryable<Jwt> GetJwts(){

        // }
    }
}
