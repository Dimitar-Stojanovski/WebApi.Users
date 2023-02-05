using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using WebApi.Users.Data.DTO_s;
using WebApi.Users.Data.Models;
using WebApi.Users.Data.Requests;
using WebApi.Users.Middleware;
using WebApi.Users.Middleware.Exceptions;
using WebApi.Users.Repositories.UserRepo;

namespace WebApi.Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;


        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;

        }


        [HttpPost("CreateUser")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        
        
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest createUserRequest)
        {
            if (!ModelState.IsValid)
            {
                return HandleError(ModelState);
            }

            var model = await userRepository.CreateUser(createUserRequest);
            return Ok(model);

        }

        [HttpGet("GetAllUsers")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        
        public async Task<IActionResult> GetAllUsers()
        {
            var _allUsers = await userRepository.GetAllUsers();
            return Ok(_allUsers);
        }

        [HttpGet("{username}")]
         public async Task<ActionResult<UserDto>> GetSingleUserWithUserName([Required] string username)
        {
            var user  = await userRepository.GetSingleUser(username);
            
            return Ok(user);
        }


        [HttpGet("firstName/lastName{username}")]
        public async Task<ActionResult<FirstAndLastNameDto>> GetFirstNameAndLastNameOfUser([Required] string username)
        {
            if (!ModelState.IsValid)
            {
                HandleError(ModelState);
            }
            var user = await userRepository.GetUserOnlyByFirstNameAndLastName(username);

            return Ok(user);
        }


        [HttpDelete("delete/{username}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
     
        public async Task<IActionResult> DeleteUserByUserName(string username)
        {
            if (!ModelState.IsValid)
            {
                return HandleError(ModelState);
            }
            await userRepository.DeleteUser(username);
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateUser([FromBody] UserDto updateUserDto)
        {
            if (!ModelState.IsValid)
            {
                return HandleError(ModelState);
            }

            var _updatedUser = await userRepository.UpdateUserInformation(updateUserDto, x =>
            {
                x.FirstName = updateUserDto.FirstName;
                x.LastName = updateUserDto.LastName;
                x.status = updateUserDto.status;
                x.Phone = updateUserDto.Phone;
                x.UserName = updateUserDto.UserName;
                x.Password = updateUserDto.Password;
            });

            return Ok(_updatedUser);
        }



        private IActionResult HandleError(ModelStateDictionary modelstate)
        {
            string messages = string.Join("; ", modelstate.Values
                .SelectMany(x => x.Errors)
                .Select(x => x.ErrorMessage));
            return BadRequest(new BadRequestException(messages));
        }
        

    }
}
