using ssoUM.DAL.Entities;
using ssoUM.DTOs;
using ssoUM.Models;
namespace ssoUM.BAL.Interface
{
    public interface IAppService
    {
        Task<IEnumerable<App>?> getAll();
        Task<bool> Insert(AppInsertDto app);

    }
}
