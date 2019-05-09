using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFGetStarted.AspNetCore.NewDb.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Angular.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private readonly BloggingContext _context;
        public SampleDataController(BloggingContext context)
        {
            _context = context;
        }
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<Blog> WeatherForecasts()
        {
            var blogs = _context.Blogs.Include(b => b.Posts);
            foreach(var a in blogs)
            {
                Console.WriteLine(a.BlogId);
            }
            return blogs;
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
