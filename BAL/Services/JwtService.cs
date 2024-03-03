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

        public async Task<IEnumerable<Jwt>?> getAll()
        {
            return await _JwtRepo.GetAsync(includeProperties: "Apps,KidNavigation");
        }

        public async Task<long> Insert(JwtInsertDto jwt)
        {
            Jwt j = new()
            {
                Description = jwt.Description,
                Kid = jwt.Kid
            };
            _JwtRepo.Add(j);
            _JwtRepo.SaveChangesManaged();
            return j.Jid;
        }
    }
}
