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
    [Route("api/posts/{postId}/[controller]")]
    [ApiController]
    public class InvitationController : ControllerBase
    {
        private readonly UserContext _context;

        public InvitationController(UserContext context)
        {
            _context = context;
        }

        // GET: api/Invitations
        [Route("/api/invitations")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invitation>>> GetInvitations()
        {
            return await _context.Invitations.ToListAsync();
        }

        // GET: api/Posts/5/Invitation
        [HttpGet]
        public async Task<ActionResult<Invitation>> GetInvitation([FromRoute] int postId)
        {
            var invitation = await _context.Invitations.Where(p => p.InvitationPostId == postId).FirstOrDefaultAsync();

            if (invitation == null)
            {
                return NotFound();
            }

            return invitation;
        }

        // POST: api/posts/5/Invitation/accept
        [HttpPost("accept")]
        public async Task<IActionResult> AcceptInvitation([FromRoute] int postId)
        {
            var invitation = await _context.Invitations
                .Where(p => p.InvitationPostId == postId)
                .Include(p => p.Guests)
                .FirstOrDefaultAsync();
            if (invitation == null)
            {
                return NotFound();
            }

            Console.WriteLine(invitation.Guests.Count);

            if (invitation.Guests.Any(p => p.GuestUserId.ToString() == User.Identity.Name))
            {
                return BadRequest();
            }

            var guest = new Guest()
            {
                GuestUserId = int.Parse(User.Identity.Name),
                GuestInvitationId = invitation.InvitationId
            };

            _context.Guests.Add(guest);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvitationExists(invitation.InvitationPostId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGuest", new { postId = postId, guestId = guest.GuestId }, guest);
        }

        // GET: api/Posts/5/Invitation/guests/4
        [HttpGet("guests/{guestId}")]
        public async Task<ActionResult<Guest>> GetGuest([FromRoute] int postId, [FromRoute] int guestId)
        {
            var guest = await _context.Guests.Where(p => p.GuestId == guestId)
                .Include(p => p.Invitation)
                .Include(p => p.User)
                .FirstOrDefaultAsync();
            
            if (guest == null)
            {
                return NotFound();
            }

            if (guest.Invitation.InvitationPostId != postId)
            {
                return BadRequest();
            }

            return guest;
        }

        // GET: api/Posts/5/Invitation/guests
        [HttpGet("guests")]
        public async Task<ActionResult<IEnumerable<Guest>>> GetGuests(int postId) {
            var invitation = await _context.Invitations
                .Where(p => p.InvitationPostId == postId)
                .Include(p => p.Guests)
                .ThenInclude(j => j.User)
                .FirstOrDefaultAsync();

            if (invitation == null)
            {
                return NotFound();
            }

            return invitation.Guests;
        }

        // PUT: api/posts/1/Invitations
        [HttpPut]
        public async Task<IActionResult> PutInvitation([FromRoute] int postId, [FromBody] Invitation invitation)
        {
            if (postId != invitation.InvitationPostId)
            {
                return BadRequest();
            }

            _context.Entry(invitation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvitationExists(postId))
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

        // POST: api/Invitations
        [HttpPost]
        public async Task<ActionResult<Invitation>> PostInvitation(Invitation invitation)
        {
            _context.Invitations.Add(invitation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvitation", new { postId = invitation.InvitationPostId }, invitation);
        }

        // DELETE: api/posts/5/Invitation
        [HttpDelete]
        public async Task<ActionResult<Invitation>> DeleteInvitation(int postId)
        {
            var invitation = await _context.Invitations.Where(p => p.InvitationPostId == postId).FirstOrDefaultAsync();
            if (invitation == null)
            {
                return NotFound();
            }

            _context.Invitations.Remove(invitation);
            await _context.SaveChangesAsync();

            return invitation;
        }

        private bool InvitationExists(int id)
        {
            return _context.Invitations.Any(e => e.InvitationPostId == id);
        }
    }
}
