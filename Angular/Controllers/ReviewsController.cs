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
    [Authorize]
    [Route("api/users/{userId}/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly UserContext _context;

        public ReviewsController(UserContext context)
        {
            _context = context;
        }

        // GET: api/users/5/Reviews
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviews(int userId)
        {
            if (!await _context.Reviews.AnyAsync(p => p.ReviewTargetId == userId))
            {
                return NotFound();
            }

            return await _context.Reviews.Where(p => p.ReviewTargetId == userId).ToListAsync();
        }

        // GET: api/users/5/Reviews/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReview(int id)
        {
            var review = await _context.Reviews.FindAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            return review;
        }

        // PUT: api/users/5/Reviews/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReview(int id, Review review)
        {
            if (id != review.ReviewId || User.Identity.Name != review.ReviewUserId.ToString())
            {
                return BadRequest();
            }

            if (!await _context.Reviews.AnyAsync(p => p.ReviewId == id && p.ReviewUserId == review.ReviewUserId && p.ReviewTargetId == review.ReviewTargetId))
            {
                return Unauthorized();
            }

            _context.Entry(review).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(id))
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

        // POST: api/users/5/Reviews
        [HttpPost]
        public async Task<ActionResult<Review>> PostReview(Review review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReview", new { id = review.ReviewId }, review);
        }

        // DELETE: api/users/5/Reviews/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Review>> DeleteReview(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            return review;
        }

        private bool ReviewExists(int id)
        {
            return _context.Reviews.Any(e => e.ReviewId == id);
        }
    }
}
