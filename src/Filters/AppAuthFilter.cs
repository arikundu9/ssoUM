using ssoUM.DAL.Enums;
using ssoUM.Model.Claims;
using ssoUM.Models.SSO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;


namespace ssoUM.Filters
{
    public class AppAuthFilterAttribute : IAuthorizationFilter
    {
        private readonly string[] _roles;
        public AppAuthFilterAttribute(string roles)
        {
            _roles = roles.Split(',');
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {

            if (context.HttpContext.Items["userclaimmodel"] != null)
            {
                AuthClaimModel userclaimmodel = (AuthClaimModel)context.HttpContext.Items["userclaimmodel"];
                List<Claim> userclaim = userclaimmodel.claims;
                bool acs = true;
                var RoleClaim = userclaim.Where(c => c.Type == "access").Select(v => JsonConvert.DeserializeObject<SsoAccess>(v.Value).ROLE).ToList();
                foreach (var role in _roles)
                {
                    acs = acs & (RoleClaim.IndexOf(role) != -1);
                }
                if (!acs)
                {
                    context.Result = new JsonResult(new { message = "ErrorMessages.Unauthorized_Acess" }) { StatusCode = StatusCodes.Status401Unauthorized };
                    return;
                }
            }
            else
            {
                context.Result = new JsonResult(new { message = "ErrorMessages.UnAuthenticated" }) { StatusCode = StatusCodes.Status401Unauthorized };
                return;
            }

        }
    }

    public class AuthorizeAttribute : TypeFilterAttribute
    {
        public AuthorizeAttribute(string roles)
            : base(typeof(AppAuthFilterAttribute))
        {
            Arguments = new object[] { roles };
        }
    }

}
