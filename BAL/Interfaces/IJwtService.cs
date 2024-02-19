using ssoUM.DAL.Entities;
using ssoUM.DTOs;
using ssoUM.Models;
namespace ssoUM.BAL.Interface
{
    public interface IJwtService
    {
        Task<IEnumerable<Jwt>?> getAll();
        Task<bool> Insert(JwtInsertDto jwt);
    }
}
