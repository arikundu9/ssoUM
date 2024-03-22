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
        public async Task<ActionResult<RestResponse<long>>> Post(JwtInsertDto Jwt)
        {
            RestResponse<long> Resp = new();
            try
            {
                Resp.Data = await _JwtService.Insert(Jwt);
                Resp.Message = $"JWT saved successfully (JWT ID: {Resp.Data})";
                return Ok(Resp);
            }
            catch (Exception ex)
            {
                return BadRequest(Resp.ErrMsg($"{((ex.InnerException != null) ? ex.InnerException.Message : ex.Message)}"));
            }
        }

        [HttpGet]
        public async Task<ActionResult<RestResponse<IEnumerable<Jwt>>>> Get(){
            RestResponse<IEnumerable<Jwt>> Resp = new();
            int a=5;
            int c=10;
            int b=c/2;
            Console.WriteLine(a==b);
            string s1 = "test";
            string s2 = "test";
            string s3 = "test1"[..4];
            Console.WriteLine(s3);
            object s4 = s3;  // Notice: set to object variable!
            Console.WriteLine($"{object.ReferenceEquals(s1, s2)} {s1 == s2} {s1.Equals(s2)}");
            Console.WriteLine($"{object.ReferenceEquals(s1, s3)} {s1 == s3} {s1.Equals(s3)}");
            Console.WriteLine($"{object.ReferenceEquals(s1, s4)} {s1 == s4} {s1.Equals(s4)}");
            try
            {
                Resp.Data = await _JwtService.getAll();
                return Ok(Resp);
            }
            catch (Exception ex)
            {
                return BadRequest(Resp.ErrMsg($"{((ex.InnerException != null) ? ex.InnerException.Message : ex.Message)}"));
            }
        }
    }
}
