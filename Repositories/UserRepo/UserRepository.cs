using AutoMapper;
using WebApi.Users.Data.DTO_s;
using WebApi.Users.Data.Models;
using WebApi.Users.Data.Requests;
using WebApi.Users.Repositories.Generics;

namespace WebApi.Users.Repositories.UserRepo
{
    public class UserRepository:GenericRepository<UserModel>, IUserRepository
    {
        private readonly UserDbContext _context;
        private readonly IMapper mapper;

        public UserRepository(UserDbContext _context, IMapper mapper ):base(_context, mapper)
        {
            this._context = _context;
            this.mapper = mapper;
        }

        public async Task<UserDto> CreateUser(CreateUserRequest createUserRequest)
        {
            var model = mapper.Map<UserModel>(createUserRequest);
            await AddAsync(model);
            return mapper.Map<UserDto>(model);
        }

        public async Task<List<UserDto>> GetAllUsers()
        {
            var _users = await GetAllAsync();
            var _records = mapper.Map<List<UserDto>>(_users);
            return _records;
        }

        public async Task<UserDto> GetSingleUser(string username)
        {
            
            var user = await GetAsync<UserModel>(x=>x.UserName==username);
            return mapper.Map<UserDto>(user);
           
            
        }
    }
}
