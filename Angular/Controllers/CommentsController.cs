using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Angular.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq.Expressions;

namespace Angular.Controllers
{
    [Authorize]
    [Route("api/posts/{postId}/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {

        private readonly UserContext _context;

        public CommentsController(UserContext context)
        {
            _context = context;
        }

        // GET: api/posts/5/comments
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentDto>>> GetComments(int postId)
        {
            // Check if the post existts, otherwise return 404
            if (!await _context.Comments.AnyAsync(p => p.CommentPostId == postId))
            {
                return NotFound();
            }

            var comments = await _context.Comments.Where(p => p.CommentPostId == postId).Select(CommentDto.Projection).ToListAsync();

            return comments;
        }

        // GET: api/posts/1/Comments/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<CommentDto>> GetComment(int id)
        {
            var comment = CommentDto.FromEntity(await _context.Comments.FirstOrDefaultAsync(p => p.CommentId == id));

            if (comment == null)
            {
                return NotFound();
            }

            return comment;
        }

        // PUT: api/posts/5/comments/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(int id, int postId, CommentDto comment)
        {
            if (id != comment.CommentId)
            {
                return BadRequest();
            }

            if (comment.CommentPostId == null && postId == 0)
            {
                comment.CommentPostId = postId;
            }
            
            if (comment.CommentPostId == 0)
            {
                return BadRequest();
            }

            if (User.Identity.Name != comment.CommentUserId.ToString())
            {
                return BadRequest();
            }

            if (!await _context.Comments.AnyAsync(p => p.CommentId == id && p.CommentUserId == comment.CommentUserId))
            {
                return BadRequest();
            }

            _context.Entry(comment.ToEntity()).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
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

        // POST: api/posts/5/comments
        [HttpPost]
        public async Task<ActionResult<Comment>> PostComment(int postId, CommentDto comment)
        {
            if (comment.CommentUserId.ToString() != User.Identity.Name)
            {
                return Unauthorized();
            }

            if (comment.CommentPostId == null && postId != 0)
            {
                comment.CommentPostId = postId;
            }

            if (comment.CommentPostId == 0)
            {
                return BadRequest();
            }

            if (!await _context.Posts.AnyAsync(p => p.PostId == comment.CommentPostId))
            {
                return NotFound();
            }

            _context.Comments.Add(comment.ToEntity());
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComment", new { id = comment.CommentId }, comment);
        }

        // DELETE: api/posts/5/Comments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Comment>> DeleteComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return comment;
        }

        private bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.CommentId == id);
        }
    }
}
