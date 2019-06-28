using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Angular.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            Media media;
            using (var fileStream = new MemoryStream())
            {
                Console.WriteLine(file.ContentType);
                await file.CopyToAsync(fileStream);
                var fileBytes = fileStream.ToArray();
                media = new Media()
                {
                    ImageData = fileBytes
                };
                _context.Medias.Add(media);

                await _context.SaveChangesAsync();
            }

            // Set it to null since this isn't the best way to encode an image (makes most debug programs crash)
            media.ImageData = null;

            return CreatedAtAction("GetFile", new { fileId = media.MediaId }, media);
        }

        [HttpGet("{fileId}")]
        [Produces("image/png")]
        public async Task<IActionResult> GetFile([FromRoute] int fileId)
        {
            var file = await _context.Medias.FindAsync(fileId);
            if(file == null)
            {
                return NotFound();
            }

            return File(file.ImageData, "image/png");
        }
    }
}