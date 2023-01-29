using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using WebApi.Users.Data.DTO_s;
using WebApi.Users.Data.Models;
using WebApi.Users.Data.Requests;
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
                return BadRequest();
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
            var user = await userRepository.GetUserOnlyByFirstNameAndLastName(username);

            return Ok(user);
        }


        

    }
}
