using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Api.Data;
using TwitterClone.Api.DTOs;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        public UsersController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        

        // /api/users
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetUsers()
        {
            var users = _userRepository.GetUsers();

            return Ok(users.Select(user => new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            }));
        }

        // /api/users
        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateUsers([FromBody] CreateUserDto createUserDto)
        {
            if(string.IsNullOrWhiteSpace(createUserDto.FirstName)||
               string.IsNullOrWhiteSpace(createUserDto.LastName) ||
               string.IsNullOrWhiteSpace(createUserDto.Email))
            {
                return BadRequest("All fields are required!");
            }

            var existingUser = _userRepository.GetUserByEmail(createUserDto.Email);

            if (existingUser != null)
            {
                return BadRequest("User already exists!");
            }

            var createdUser = _userRepository.AddUser(new User
            {
                FirstName = createUserDto.FirstName,
                LastName = createUserDto.LastName,
                Email = createUserDto.Email,
            });


            return Ok(new UserDto
            {
                Id = createdUser.Id,
                FirstName = createdUser.FirstName,
                LastName = createdUser.LastName,
                Email = createdUser.Email
            });
        }

        // /api/users/{id}
        [HttpGet("{id}")]
        public IActionResult GetUserById([FromRoute] Guid id)
        {
            var user = _userRepository.GetUserByID(id);

            if(user == null)
            {
                return NotFound();
            }
            return Ok(new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            });
        }

        // /api/users/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateUsers([FromRoute] Guid id, [FromBody] UpdateUserDto updateUserDto)
        {
            var user = _userRepository.GetUserByID(id);

            if(user == null)
            {
                return NotFound();
            }
            user.FirstName = updateUserDto.FirstName;
            user.LastName = updateUserDto.LastName;

            _userRepository.UpdateUser(user);

            return Ok(user);
        }

        // /api/users/{id}/phoneNumber
        [HttpPatch("{id}/phoneNumber")]
        public IActionResult UpdateUserPhoneNumber([FromRoute] Guid id, [FromBody] string phoneNumber)
        {
            return Ok("hello");
        }


        // /api/users/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteUserByID([FromRoute] Guid id)
        {
            var user = _userRepository.GetUserByID(id);

            if (user == null)
            {
                return NotFound();
            }

            var isDeleted = _userRepository.DeleteUser(user);

            return Ok(isDeleted);
        }


    }

  
}
