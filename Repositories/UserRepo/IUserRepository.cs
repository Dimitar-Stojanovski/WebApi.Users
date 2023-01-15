using WebApi.Users.Data.DTO_s;
using WebApi.Users.Data.Models;
using WebApi.Users.Data.Requests;
using WebApi.Users.Repositories.Generics;

namespace WebApi.Users.Repositories.UserRepo
{
    public interface IUserRepository:IGenericRepository<User>
    {
        Task<UserDto> CreateUser(CreateUserRequest createUserRequest);
    }
}
