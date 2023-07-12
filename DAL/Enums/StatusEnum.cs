using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace ssoUM.DAL.Enums
{
    public enum APIResponseStatus
    {
        Success = 1,
        Warning = 2,
        Error = 3
    }

    public enum TokenType
    {
        AccessToken = 1
        //RefresToken = 2
    }

    public enum ClaimType
    {
        UserId = 1,
        //UserType = 2,
        Email = 3,
        //Jti = 4,
        Role = 5,
        TokenType = 6
    }

}
