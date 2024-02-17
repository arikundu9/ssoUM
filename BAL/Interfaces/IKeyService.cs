using ssoUM.DTOs;
using ssoUM.Models;
namespace ssoUM.BAL.Interface
{
    public interface IKeyService
    {
        Task<bool> Insert(KeyInsertDto key);
    }
}
