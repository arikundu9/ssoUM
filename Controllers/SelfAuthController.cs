using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ssoUM.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.10")]
    public class SelfAuthController : ControllerBase
    {
        public IConfiguration Configuration { get; }
        public SelfAuthController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public ActionResult<string> Login()
        {
            return "Login";
        }
        [HttpPost("Register")]
        [AllowAnonymous]
        public ActionResult<string> Register()
        {
            return "Register";
        }
        [HttpPost("PasswordChange")]
        [AllowAnonymous]
        public ActionResult<string> PasswordChange()
        {
            return "PasswordChange";
        }
    }
}
