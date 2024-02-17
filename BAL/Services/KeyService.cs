using AutoMapper;
using ssoUM.BAL.Interface;
using ssoUM.DAL.Entities;
using ssoUM.DAL.Interfaces;
using ssoUM.DTOs;
using ssoUM.Models;
namespace ssoUM.BAL
{
    public class KeyService : IKeyService
    {
        private readonly IKeyRepo _KeyRepo;
        private readonly IMapper _mapper;
        public KeyService(IKeyRepo KeyRepo, IMapper mapper)
        {
            _KeyRepo = KeyRepo;
            _mapper = mapper;
        }

        public async Task<bool> Insert(KeyInsertDto key)
        {
            _KeyRepo.Add(new Key()
            {
                Type = key.Type,
                PrivateKey = key.PrivateKey,
                PublicKey = key.PublicKey,
                Algo = key.Algo
            });
            _KeyRepo.SaveChangesManaged();
            return true;
        }
    }
}
