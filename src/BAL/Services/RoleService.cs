using AutoMapper;
using ssoUM.BAL.Interface;
using ssoUM.DAL.Entities;
using ssoUM.DAL.Interfaces;
using ssoUM.Models;
namespace ssoUM.BAL
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepo _RoleRepo;
        private readonly IMapper _mapper;
        public RoleService(IRoleRepo RoleRepo, IMapper mapper) {
            _RoleRepo = RoleRepo;
            _mapper = mapper;
        }
    }
}
