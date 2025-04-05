using Microsoft.AspNetCore.Mvc;
using ASP.Net_Homework.Models;
using ASP.Net_Homework.Repositories.Interfaces;

namespace ASP.Net_Homework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userRepository.GetUsers();
            if (users == null || !users.Any())
                return NotFound();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser([FromRoute] int id)
        {
            var user = await _userRepository.GetUser(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] User newUser)
        {
            var createdUser = await _userRepository.CreateUser(newUser);
            return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser([FromRoute] int id, [FromBody] User newUser)
        {
            var updatedUser = await _userRepository.UpdateUser(newUser);
            return Ok(updatedUser);
        }
    }
}


