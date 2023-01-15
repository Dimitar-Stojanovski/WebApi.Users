using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IMapper mapper;

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
    }
}
