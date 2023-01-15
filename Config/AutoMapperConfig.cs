using AutoMapper;
using WebApi.Users.Data.DTO_s;
using WebApi.Users.Data.Models;
using WebApi.Users.Data.Requests;

namespace WebApi.Users.Config
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
           CreateMap<CreateUserRequest, UserDto>().ReverseMap();
           CreateMap<UserModel, UserDto>().ReverseMap();
           CreateMap<UserModel, CreateUserRequest>().ReverseMap();

        }
    }
}
