using AutoMapper;
using ssoUM.BAL.Interface;
using ssoUM.DAL.Entities;
using ssoUM.DAL.Interfaces;
using ssoUM.Models;
namespace ssoUM.BAL
{
    public class AppService : IAppService
    {
        private readonly IAppRepo _AppRepo;
        private readonly IMapper _mapper;
        public AppService(IAppRepo AppRepo, IMapper mapper) {
            _AppRepo = AppRepo;
            _mapper = mapper;
        }
    }
}
