using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Angular.Models;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Examples;

namespace Angular.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly UserContext _context;

        public PostsController(UserContext context)
        {
            _context = context;
        }

        // GET: api/Users/5/posts
        [HttpGet("/api/users/{userId}/posts")]
        [ProducesResponseType(typeof(IEnumerable<PostDto>), 200)]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetPosts(int userId)
        {
            return await _context.Posts
                .Where(p => p.PostUserId == userId)
                .Include(p => p.Invitation)
                .Include(p => p.Comments)
                .Select(PostDto.Projection)
                .ToListAsync(); ;
        }

        // GET: api/Posts/5
        [ProducesResponseType(typeof(PostDto), 200)]
        [HttpGet("{id}")]
        public async Task<ActionResult<PostDto>> GetPost(int id)
        {
            var post = await _context.Posts
                .Where(p => p.PostId == id)
                .Include(p => p.User)
                .Include(p => p.Comments)
                .Select(PostDto.Projection)
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
        public async Task<IActionResult> PutPost(int id, PostDto post)
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
                

            _context.Entry(post.ToEntity()).State = EntityState.Modified;

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
        [SwaggerResponseExample(200, typeof(PostDto))]
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(PostDto postDto)
        {
            var post = postDto.ToEntity();

            post.PostUserId = int.Parse(User.Identity.Name);

            post.PostedAt = DateTime.UtcNow;

            _context.Posts.Add(post);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPost", new { id = post.PostId }, post);
        }

        // DELETE: api/Posts/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<PostDto>> DeletePost(int id)
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

            return PostDto.FromEntity(post);
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.PostId == id);
        }
    }
}
