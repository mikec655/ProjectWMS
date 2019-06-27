using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Angular.Models;
using Angular.Utils;
using MemoryGame.Services;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Examples;
using System.Net;

namespace Angular.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserContext _context;
        private readonly IUserService _userService;

        public UsersController(UserContext context, IUserService userService)
        {
            _userService = userService;
            _context = context;
        }

        /// <summary>
        /// Gets list of all UserAccounts
        /// </summary>
        /// <returns>Array with UserAccounts</returns>
        // GET: api/Users
        [HttpGet]
        public IEnumerable<UserAccount> GetUsers()
        {
            return _context.Users;
        }

        /// <summary>
        /// Login to the given UserAccount
        /// </summary>
        /// <param name="userDto">UserAccount, only Username and Password are required</param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(UserAccount), 200)]
        [SwaggerRequestExample(typeof(UserAccountDto), typeof(LoginRequestExample))]
        [SwaggerResponseExample(200, typeof(UserDtoResponseExample))]
        [AllowAnonymous]
        [Route("/api/login")]
        [HttpPost]
        public ActionResult<UserAccountDto> Login([FromBody] UserAccountDto userDto)
        {
            var user = _userService.Authenticate(userDto.Username, userDto.Password);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            return UserAccountDto.FromEntity(user);
        }

        /// <summary>
        /// Get the data for the given UserId
        /// </summary>
        /// <param name="id">The User ID</param>
        /// <returns>UserAccount data</returns>
        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserAccount user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            if (User.Identity.Name != user.UserId.ToString())
            {
                return Unauthorized();
            }

            // Remove password if running on Release, could be used for debugging so that's why the pragma is used
            user.ToDto();

            return Ok(user);
        }

        /// <summary>
        /// Update the given UserAccount
        /// </summary>
        /// <param name="id">The ID to update</param>
        /// <param name="user">The new UserAccount data</param>
        /// <returns></returns>
        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser([FromRoute] int id, [FromBody] UserAccount user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserId)
            {
                return BadRequest();
            }

            if (User.Identity.Name != id.ToString())
            {
                return Unauthorized();
            }

            user.ToEntity();

            user.Password = Hash.GenerateHash(user.Password);

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Adds the given user to the database
        /// </summary>
        /// <param name="user">The user to add to the database</param>
        /// <returns></returns>
        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] UserAccount user)
        {
            if (!ModelState.IsValid || string.IsNullOrWhiteSpace(user.Password) || string.IsNullOrWhiteSpace(user.Username))
            {
                return BadRequest(ModelState);
            }

            user.ToEntity();

            await _userService.RegisterAsync(user);

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        /// <summary>
        /// Deletes the given account from the database
        /// </summary>
        /// <param name="id">The User ID to remove</param>
        /// <returns>The Deleted User object</returns>
        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (User.Identity.Name != id.ToString())
            {
                return Unauthorized();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }

    public class LoginRequestExample : IExamplesProvider
    {
        public virtual object GetExamples()
        {
            return new UserAccountDto() {
                Username = "Test",
                Password = "Wachtwoord"
            };
        }
    }

    public class UserDtoResponseExample : IExamplesProvider
    {
        public virtual object GetExamples()
        {
            return new UserAccountDto()
            {
                UserId = 1,
                Username = "Test",
                Firstname = "Jans",
                Lastname = "Jansen",
                Gender = "M",
                BirthDateUnix = 1561511612130,
                Street = "Hoofdkade",
                Number = 0611992103,
                ZipCode = "9503HH",
                City = "Stadskanaal",
                ProfilePicture = "Putin.jpg",
                ProfileDescription = "Kaas",
                Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJuYmYiOjE1NjE1OTkwNTcsImV4cCI6MTU2MjIwMzg1NywiaWF0IjoxNTYxNTk5MDU3fQ.d4LYTe3c0s_8QLqQqfZvHDpuk2KP6YTpF_WrB-hT8rQ"
            };
        }
    }
}