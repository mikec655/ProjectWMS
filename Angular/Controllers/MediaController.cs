using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Angular.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly UserContext _context;
        public MediaController(UserContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> PostFile(IFormFile file)
        {
            if(!Regex.IsMatch(file.ContentType, "image/*"))
            {
                return BadRequest();
            }

            Media media;
            using (var fileStream = new MemoryStream())
            {
                await file.CopyToAsync(fileStream);
                var fileBytes = fileStream.ToArray();
                Console.WriteLine(fileBytes.Length);
                media = new Media()
                {
                    Type = file.ContentType,
                    ImageData = fileBytes,
                    MediaUserAccountId = int.Parse(User.Identity.Name)
                };
                _context.Medias.Add(media);

                await _context.SaveChangesAsync();
            }

            // Set it to null since this isn't the best way to encode an image (makes most debug programs crash)
            media.ImageData = null;

            return CreatedAtAction("GetFile", new { fileId = media.MediaId }, media);
        }

        [HttpPut("{fileId}")]
        public async Task<IActionResult> PutFile([FromRoute] int fileId, IFormFile file)
        {
            if (!Regex.IsMatch(file.ContentType, "image/*"))
            {
                return BadRequest();
            }

            if (!_context.Medias.Any(p => p.MediaId == fileId && p.MediaUserAccountId.GetValueOrDefault().ToString() == User.Identity.Name)) {
                return Unauthorized();
            }

            Media media;
            using (var fileStream = new MemoryStream())
            {
                await file.CopyToAsync(fileStream);
                var fileBytes = fileStream.ToArray();
                Console.WriteLine(fileBytes.Length);
                media = new Media()
                {
                    MediaId = fileId,
                    Type = file.ContentType,
                    ImageData = fileBytes,
                    MediaUserAccountId = int.Parse(User.Identity.Name)
                };
                _context.Entry(media).State = EntityState.Modified;

                await _context.SaveChangesAsync();
            }

            return NoContent();
        }

        [HttpGet("{fileId}")]
        public async Task<IActionResult> GetFile([FromRoute] int fileId)
        {
            var file = await _context.Medias.FindAsync(fileId);
            if(file == null)
            {
                return NotFound();
            }

            return File(file.ImageData, file.Type);
        }

        [HttpDelete("{fileId}")]
        public async Task<IActionResult> DeleteFile([FromRoute] int fileId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var file = await _context.Medias.FindAsync(fileId);

            if (file == null)
            {
                return NotFound();
            }

            if (User.Identity.Name != file.MediaUserAccountId?.ToString())
            {
                return Unauthorized();
            }

            _context.Medias.Remove(file);
            await _context.SaveChangesAsync();

            return Ok(file);
        }
    }
}