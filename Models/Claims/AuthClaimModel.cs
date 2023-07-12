using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ssoUM.Model.Claims
{
    public class AuthClaimModel
    {
        public List<Claim> claims { get; set; }
        public string RefreshedAccessToken { get; set; }
    }
}
