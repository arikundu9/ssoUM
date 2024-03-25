using ssoUM.DAL.Entities;
using ssoUM.DAL.Interfaces;
namespace ssoUM.DAL
{
   public class KeyRepo : Repository<Key, ssoUMDBContext>, IKeyRepo
   {
       public KeyRepo(ssoUMDBContext context) : base(context)
       {
       }
   }
}
