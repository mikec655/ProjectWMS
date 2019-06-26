using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Angular.Models;
using Microsoft.AspNetCore.Authorization;

namespace Angular.Controllers
{
    public class PostVM
    {
        public int PostId { get; set; }

        public int PostUserId { get; set; }

        public string UserFirstName { get; set; }

        public string UserLastName { get; set; }

        public long PostedAtUnix { get; set; }

        public string Message { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly UserContext _context;

        public PostsController(UserContext context)
        {
            _context = context;
        }

        // GET: api/Posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostVM>> GetPost(int id)
        {
            var post = await _context.Posts
                .Where(p => p.PostId == id)
                .Include(p => p.User)
                .Select(p => new PostVM
                {
                    PostId = p.PostId,
                    PostUserId = p.PostUserId,
                    PostedAtUnix = new DateTimeOffset(p.PostedAt.Value.ToUniversalTime()).ToUnixTimeMilliseconds(),
                    Message = p.Message,
                    UserFirstName = p.User.Firstname,
                    UserLastName = p.User.Lastname
                })
                .FirstOrDefaultAsync();

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

        // PUT: api/Posts/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, Post post)
        {
            if (id != post.PostId)
            {
                return BadRequest();
            }

            if (post.PostUserId.ToString() != User.Identity.Name)
            {
                return Unauthorized();
            }

            if (!await _context.Posts.AnyAsync(p => p.PostId == id && p.PostUserId == post.PostUserId))
            {
                return BadRequest();
            }
                

            _context.Entry(post).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
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

        // POST: api/Posts
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(Post post)
        {
            post.ToEntity();

            post.PostedAt = DateTime.UtcNow;

            _context.Posts.Add(post);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPost", new { id = post.PostId }, new PostVM
                {
                    PostId = post.PostId,
                    PostUserId = post.PostUserId,
                    PostedAtUnix = new DateTimeOffset(post.PostedAt.Value.ToUniversalTime()).ToUnixTimeMilliseconds(),
                    Message = post.Message,
                });
        }

        // DELETE: api/Posts/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Post>> DeletePost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            if (post.PostUserId.ToString() != User.Identity.Name)
            {
                return Unauthorized();
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return post;
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.PostId == id);
        }
    }
}
