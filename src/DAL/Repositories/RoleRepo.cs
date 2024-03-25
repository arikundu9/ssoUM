using ssoUM.DAL.Entities;
using ssoUM.DAL.Interfaces;
namespace ssoUM.DAL
{
   public class RoleRepo : Repository<Role, ssoUMDBContext>, IRoleRepo
   {
       public RoleRepo(ssoUMDBContext context) : base(context)
       {
       }
   }
}
