using AutoMapper;
using ssoUM.BAL.Interface;
using ssoUM.DAL.Entities;
using ssoUM.DAL.Interfaces;
using ssoUM.Models;
namespace ssoUM.BAL
{
	public class UserService : IUserService
	{
		private readonly IUserRepo _UserRepo;
		private readonly IMapper _mapper;
		public UserService(IUserRepo UserRepo, IMapper mapper)
		{
			_UserRepo = UserRepo;
			_mapper = mapper;
		}
	}
}
