using AutoMapper;
using ssoUM.BAL.Interface;
using ssoUM.DAL.Entities;
using ssoUM.DAL.Interfaces;
using ssoUM.Models;
namespace ssoUM.BAL
{
    public class KeyService : IKeyService
    {
        private readonly IKeyRepo _KeyRepo;
        private readonly IMapper _mapper;
        public KeyService(IKeyRepo KeyRepo, IMapper mapper) {
            _KeyRepo = KeyRepo;
            _mapper = mapper;
        }
    }
}
