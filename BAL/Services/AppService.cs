using AutoMapper;
using ssoUM.BAL.Interface;
using ssoUM.DAL.Entities;
using ssoUM.DAL.Interfaces;
using ssoUM.DTOs;
using ssoUM.Models;
namespace ssoUM.BAL
{
    public class AppService : IAppService
    {
        private readonly IAppRepo _AppRepo;
        private readonly IMapper _mapper;
        public AppService(IAppRepo AppRepo, IMapper mapper)
        {
            _AppRepo = AppRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<App>?> getAll()
        {
            return await _AppRepo.GetAsync(includeProperties: "Roles,Users,JidNavigation");
        }

        public async Task<long> Insert(AppInsertDto app)
        {
            App a = new()
            {
                Redirecturl = app.Redirecturl,
                Jid = app.Jid,
                AppName = app.AppName
            };
            _AppRepo.Add(a);
            _AppRepo.SaveChangesManaged();
            return a.Aid;
        }

    }
}
