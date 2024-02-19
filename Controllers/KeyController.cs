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
    public class KeyController : ControllerBase
    {
        public IConfiguration Configuration { get; }

        private readonly IKeyService _KeyService;

        public KeyController(IConfiguration configuration, IKeyService KeyService)
        {
            Configuration = configuration;
            _KeyService = KeyService;
        }
        [HttpPost]
        public async Task<ActionResult<RestResponse<bool>>> Post(KeyInsertDto Key)
        {
            RestResponse<bool> Resp = new();
            try
            {
                Resp.Data = await _KeyService.Insert(Key);
                return Ok(Resp);
            }
            catch (Exception ex)
            {
                return BadRequest(Resp.ErrMsg($"{((ex.InnerException != null) ? ex.InnerException.Message : ex.Message)}"));
            }
        }

        [HttpGet]
        public async Task<ActionResult<RestResponse<IEnumerable<Key>>>> GetKeys(){
            RestResponse<IEnumerable<Key>> Resp = new();
            try
            {
                Resp.Data = await _KeyService.getAll();
                return Ok(Resp);
            }
            catch (Exception ex)
            {
                return BadRequest(Resp.ErrMsg($"{((ex.InnerException != null) ? ex.InnerException.Message : ex.Message)}"));
            }
        }
    }
}
