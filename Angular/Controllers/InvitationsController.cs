using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Angular.Models;
using Microsoft.AspNetCore.Authorization;
using NetTopologySuite.Geometries;
using System.Dynamic;
using Newtonsoft.Json.Linq;

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

        // GET: api/users/5/invitations
        /// <summary>
        /// Gets the invitations sorted on distance
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="expandoObject">JSON object containing long and lat</param>
        /// <returns></returns>
        [Route("/api/users/{userId}/invitations")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvitationDto>>> GetUserInvitations([FromRoute] int userId, [FromBody] JObject expandoObject)
        {
            var longitude = expandoObject.Value<double>("long");
            var latitude = expandoObject.Value<double>("lat");
            Console.WriteLine($"longitude: {longitude}; latitude: {latitude}");
            var location = new Point(longitude, latitude) { SRID = 4326 };
            return await _context.Invitations
                .Include(p => p.Post)
                .Where(p => p.Post.PostUserId == userId)
                .OrderBy(p => p.LocationPoint.Distance(location))
                .Select(InvitationDto.Projection)
                .ToListAsync();
        }

        // GET: api/Posts/5/Invitation
        [HttpGet]
        public async Task<ActionResult<InvitationDto>> GetInvitation([FromRoute] int postId)
        {
            var invitation = await _context.Invitations
                .Include(p => p.Guests)
                .Where(p => p.InvitationPostId == postId)
                .FirstOrDefaultAsync();

            if (invitation == null)
            {
                return NotFound();
            }

            return InvitationDto.ToDto(invitation);
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

            if (invitation.Guests.Any(p => p.GuestUserId.ToString() == User.Identity.Name) && invitation.NumberOfGuests >= invitation.Guests.Count)
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

            return CreatedAtAction("GetGuest", new { postId, guestId = guest.GuestId }, guest);
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
        public async Task<IActionResult> PutInvitation([FromRoute] int postId, [FromBody] InvitationDto invitation)
        {
            if (postId != invitation.InvitationPostId)
            {
                return BadRequest();
            }

            _context.Entry(invitation.ToEntity()).State = EntityState.Modified;

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

        // POST: api/Posts/5/Invitations
        [HttpPost]
        public async Task<ActionResult<Invitation>> PostInvitation(int postId, InvitationDto invitation)
        {
            if (postId != invitation.InvitationPostId)
            {
                return BadRequest();
            }

            _context.Invitations.Add(invitation.ToEntity());
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvitation", new { postId = invitation.InvitationPostId }, invitation);
        }

        // DELETE: api/posts/5/Invitation
        [HttpDelete]
        public async Task<ActionResult<InvitationDto>> DeleteInvitation(int postId)
        {
            var invitation = await _context.Invitations.Where(p => p.InvitationPostId == postId).FirstOrDefaultAsync();
            if (invitation == null)
            {
                return NotFound();
            }

            _context.Invitations.Remove(invitation);
            await _context.SaveChangesAsync();

            return InvitationDto.ToDto(invitation);
        }

        private bool InvitationExists(int id)
        {
            return _context.Invitations.Any(e => e.InvitationPostId == id);
        }
    }
}
