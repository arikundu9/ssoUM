using ssoUM.DTOs;
using ssoUM.Models;
namespace ssoUM.BAL.Interface
{
    public interface IAppService
    {
        Task<bool> Insert(AppInsertDto app);

    }
}
