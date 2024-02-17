using AutoMapper;
using ssoUM.BAL.Interface;
using ssoUM.DAL.Entities;
using ssoUM.DAL.Interfaces;
using ssoUM.DTOs;
using ssoUM.Models;
namespace ssoUM.BAL
{
    public class JwtService : IJwtService
    {
        private readonly IJwtRepo _JwtRepo;
        private readonly IMapper _mapper;
        public JwtService(IJwtRepo JwtRepo, IMapper mapper)
        {
            _JwtRepo = JwtRepo;
            _mapper = mapper;
        }

        public async Task<bool> Insert(JwtInsertDto jwt)
        {
            _JwtRepo.Add(new Jwt()
            {
                Description = jwt.Description,
                Kid = jwt.Kid
            });
            _JwtRepo.SaveChangesManaged();
            return true;
        }
    }
}
