using ssoUM.DAL.Entities;
using ssoUM.DAL.Interfaces;
namespace ssoUM.DAL
{
	public class UserRepo : Repository<User, ssoUMDBContext>, IUserRepo
	{
		public UserRepo(ssoUMDBContext context) : base(context)
		{
		}
	}
}
