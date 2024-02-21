using ssoUM.DAL.Entities;
using ssoUM.DTOs;
using ssoUM.Models;
namespace ssoUM.BAL.Interface
{
    public interface IAppService
    {
        Task<IEnumerable<App>?> getAll();
        Task<long> Insert(AppInsertDto app);

    }
}
