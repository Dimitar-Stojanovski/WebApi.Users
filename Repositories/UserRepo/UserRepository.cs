using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApi.Users.Data.DTO_s;
using WebApi.Users.Data.Models;
using WebApi.Users.Data.Requests;
using WebApi.Users.Middleware.Exceptions;
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

        public async Task DeleteUser(string username)
        {
            var user = (await GetAsync<UserModel>(x => x.UserName == username));
            if (user == null)
            {
                throw new NotFoundException($"Cannot find a user with the username:{username}");
            }

            await DeleteAsync(user);
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
            if (user == null)
            {
                throw new NotFoundException($"User with the following username: {username} is not found");
            }
            return mapper.Map<UserDto>(user);
           
            
        }


        public async Task<FirstAndLastNameDto> GetUserOnlyByFirstNameAndLastName(string _username)
        {
            
            var user = await QueryByCondition<UserModel>(x=>x.UserName == _username)
                .Select(x=>new FirstAndLastNameDto()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                }).FirstOrDefaultAsync();

            if (user == null)
            {
                throw new NotFoundException($"User with{_username}, is not found");
            }

            return mapper.Map<FirstAndLastNameDto>(user);
        }
    }
}
