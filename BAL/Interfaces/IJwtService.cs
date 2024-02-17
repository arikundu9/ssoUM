using ssoUM.DTOs;
using ssoUM.Models;
namespace ssoUM.BAL.Interface
{
    public interface IJwtService
    {
        Task<bool> Insert(JwtInsertDto jwt);
    }
}
