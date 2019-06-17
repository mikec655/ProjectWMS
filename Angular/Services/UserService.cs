﻿using Angular.Utils;
using Angular.Models;
using Angular.Utils;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame.Services
{
    // Based upon: https://jasonwatmore.com/post/2018/08/14/aspnet-core-21-jwt-authentication-tutorial-with-example-api
    public interface IUserService
    {
        User Authenticate(string username, string password);
        User Register(string username, string password);
        IEnumerable<User> GetAll();
    }
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly UserContext _context;

        public UserService(IOptions<AppSettings> appSettings, UserContext userContext)
        {
            _appSettings = appSettings.Value;
            _context = userContext;
        }

        public User Authenticate(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(x => x.Username == username);

            if (user == null)
                return null;

            if (!Hash.VerifyPassword(user.Password, password))
            {
                return null;
            }

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            user.Password = null;

            return user;
        }

        public User Register(string username, string password)
        {

            var user = _context.Users.FirstOrDefault(x => x.Username == username);
            if (user != null)
            {
                return null;
            }

            var newUser = new User { Password = Hash.GenerateHash(password), Username = username };

            _context.Users.AddAsync(newUser);
            _context.SaveChangesAsync();

            return newUser;
        }

        public async Task<User> RegisterAsync(User user)
        {

            var existingUser = _context.Users.FirstOrDefault(x => x.Username == user.Username);
            if (existingUser != null)
            {
                return null;
            }

            user.Password = Hash.GenerateHash(user.Password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            user = Authenticate(user.Username, user.Password);

            user.Password = null;

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            var query = from Users in _context.Users
                        select Users;
            return query.Select(user => new User { UserId = user.UserId, Username = user.Username });
        }
    }
}
