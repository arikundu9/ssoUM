using ssoUM.DAL.Entities;
using ssoUM.DTOs;
using ssoUM.Models;
namespace ssoUM.BAL.Interface
{
    public interface IKeyService
    {
        Task<IEnumerable<Key>?> getAll();
        Task<bool> Insert(KeyInsertDto key);
    }
}
