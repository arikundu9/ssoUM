using ssoUM.DAL.Entities;
using ssoUM.DAL.Interfaces;
namespace ssoUM.DAL
{
	public class JwtRepo : Repository<Jwt, ssoUMDBContext>, IJwtRepo
	{
		public JwtRepo(ssoUMDBContext context) : base(context)
		{
		}
	}
}
