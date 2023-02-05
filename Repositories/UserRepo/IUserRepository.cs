using WebApi.Users.Data.DTO_s;
using WebApi.Users.Data.Models;
using WebApi.Users.Data.Requests;
using WebApi.Users.Repositories.Generics;

namespace WebApi.Users.Repositories.UserRepo
{
    public interface IUserRepository:IGenericRepository<UserModel>
    {
        Task<UserDto> CreateUser(CreateUserRequest createUserRequest);
        Task<List<UserDto>> GetAllUsers();
        Task<UserDto> GetSingleUser(string username);
        Task DeleteUser(string username);
        Task<FirstAndLastNameDto> GetUserOnlyByFirstNameAndLastName(string _username);
        Task<UserDto> UpdateUserInformation(UserDto user, Action<UserModel> actionRequest);
    }
}
