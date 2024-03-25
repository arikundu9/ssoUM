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
        public async Task<ActionResult<RestResponse<long>>> Post(KeyInsertDto Key)
        {
            RestResponse<long> Resp = new();
            try
            {
                Resp.Data = await _KeyService.Insert(Key);
                Resp.Message = $"Key saved successfully (Key ID: {Resp.Data})";
                return Ok(Resp);
            }
            catch (Exception ex)
            {
                return BadRequest(Resp.ErrMsg($"{((ex.InnerException != null) ? ex.InnerException.Message : ex.Message)}"));
            }
        }

        [HttpGet]
        public async Task<ActionResult<RestResponse<IEnumerable<Key>>>> Get(){
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
