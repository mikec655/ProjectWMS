using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Angular.Models;

namespace Angular.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private readonly UserContext _context;
        public SampleDataController(UserContext context)
        {
            _context = context;
        }
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

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

        public ActionResult Login([FromBody] User userInfo)
        {
            Console.WriteLine(userInfo?.Username);
            var email = userInfo.Username.ToString();
            var query = from User in _context.Users
                        where User.Username == userInfo.Username
                        select User;
                
            if (query.Count() != 1)
            {
                return Json(null);
            }
            var user = query.FirstOrDefault();
            if (user.Password == userInfo.Password)
            {
                Console.WriteLine($"Login succeeded. email: {user.Username}; password: {user.Password}");
                return Json(user);
            }
            else
            {
                Console.WriteLine("Incorrect password.");
                return Json(false);
            }

            return Json(null);
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
