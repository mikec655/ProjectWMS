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

        // GET: api/Users
        [HttpGet]
        public IEnumerable<UserAccount> GetUsers()
        {
            return _context.Users;
        }

        [AllowAnonymous]
        [Route("/api/login")]
        [HttpPost]
        public ActionResult<UserAccount> Login([FromBody] UserAccount user)
        {
            Console.WriteLine($"{user.Username} : {user.Password}");
            user = _userService.Authenticate(user.Username, user.Password);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            return user;
        }

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
            user.Password = null;

            user.BirthDateUnix = new DateTimeOffset(user.BirthDate.Value.ToUniversalTime()).ToUnixTimeMilliseconds();
            user.BirthDate = null;

            return Ok(user);
        }

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

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] UserAccount user)
        {
            if (!ModelState.IsValid || string.IsNullOrWhiteSpace(user.Password) || string.IsNullOrWhiteSpace(user.Username))
            {
                return BadRequest(ModelState);
            }

            var newUser = await _userService.RegisterAsync(user);

            if(newUser == null)
            {
                return NotFound();
            }

            return Ok(newUser);
        }

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
}