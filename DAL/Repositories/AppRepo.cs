using ssoUM.DAL.Entities;
using ssoUM.DAL.Interfaces;
namespace ssoUM.DAL
{
	public class AppRepo : Repository<App, ssoUMDBContext>, IAppRepo
	{
		public AppRepo(ssoUMDBContext context) : base(context)
		{
		}
	}
}
