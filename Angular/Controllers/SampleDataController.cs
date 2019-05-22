using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFGetStarted.AspNetCore.NewDb.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Dynamic;
using Newtonsoft.Json.Linq;

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

        [HttpPost("[action]")]
        public ActionResult Register([FromBody]dynamic value)
        {
            var userInfo = value.ToObject<User>();
            Console.WriteLine(userInfo?.Email);
            _context.Add<User>(userInfo);
            _context.SaveChangesAsync();
            Console.WriteLine($"email: {value?.GetType()}");
            var response = value;
            return Json(userInfo);
        }

        // No clue why but changing it to anything but dynamic breaks it, it receives a JObject but setting type to that doesn't work.
        [HttpPost("[action]")]
        public ActionResult Login([FromBody]dynamic value)
        {
            if (value is JObject jObject)
            {
                var userInfo = jObject.ToObject<User>();
                Console.WriteLine(userInfo?.Email);
                var email = userInfo.Email.ToString();
                var query = from User in _context.Users
                            where User.Email == userInfo.Email
                            select User;
                if (query.Count() != 1)
                {
                    return Json(null);
                }
                var user = query.FirstOrDefault();
                if (user.Password == userInfo.Password)
                {
                    Console.WriteLine($"Login succeeded. email: {user.Email}; password: {user.Password}");
                    return Json(user);
                }
                else
                {
                    Console.WriteLine("Incorrect password.");
                    return Json(false);
                }
            }
            return Json(null);
        }

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

        public class UserInfo
        {
            public string email { get; set; }
            public string password { get; set; }
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
