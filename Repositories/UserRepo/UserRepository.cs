using AutoMapper;
using WebApi.Users.Data.DTO_s;
using WebApi.Users.Data.Models;
using WebApi.Users.Data.Requests;
using WebApi.Users.Repositories.Generics;

namespace WebApi.Users.Repositories.UserRepo
{
    public class UserRepository:GenericRepository<User>, IUserRepository
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
            var model = mapper.Map<User>(createUserRequest);
            await AddAsync(model);
            return mapper.Map<UserDto>(model);
        }
    }
}
