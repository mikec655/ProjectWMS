using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Angular.Models;

namespace Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvitationsController : ControllerBase
    {
        private readonly UserContext _context;

        public InvitationsController(UserContext context)
        {
            _context = context;
        }

        // GET: api/Invitations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invitation>>> GetInvitations()
        {
            return await _context.Invitations.ToListAsync();
        }

        // GET: api/Invitations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Invitation>> GetInvitation(int id)
        {
            var invitation = await _context.Invitations.FindAsync(id);

            if (invitation == null)
            {
                return NotFound();
            }

            return invitation;
        }

        // PUT: api/Invitations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvitation(int id, Invitation invitation)
        {
            if (id != invitation.InvitationId)
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
                if (!InvitationExists(id))
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

            return CreatedAtAction("GetInvitation", new { id = invitation.InvitationId }, invitation);
        }

        // DELETE: api/Invitations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Invitation>> DeleteInvitation(int id)
        {
            var invitation = await _context.Invitations.FindAsync(id);
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
            return _context.Invitations.Any(e => e.InvitationId == id);
        }
    }
}
