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

        public async Task<bool> Insert(AppInsertDto app)
        {
            _AppRepo.Add(new App()
            {
                Redirecturl = app.Redirecturl,
                Jid = app.Jid,
                AppName = app.AppName
            });
            _AppRepo.SaveChangesManaged();
            return true;
        }

    }
}
