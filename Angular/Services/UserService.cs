using Angular.Utils;
using Angular.Models;
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
        UserAccount Authenticate(string username, string password);
        void Register(string username, string password);

        Task<UserAccount> RegisterAsync(UserAccount user);

        IEnumerable<UserAccount> GetAll();

        string GenerateToken(string userId);
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

        public UserAccount Authenticate(string username, string password)
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

        public string GenerateToken(string userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userId)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public void Register(string username, string password)
        {

            var user = _context.Users.FirstOrDefault(x => x.Username == username);
            if (user != null)
            {
                return;
            }

            var newUser = new UserAccount { Password = Hash.GenerateHash(password), Username = username };

            _context.Users.AddAsync(newUser);
            _context.SaveChangesAsync();;
        }

        public async Task<UserAccount> RegisterAsync(UserAccount user)
        {

            var existingUser = _context.Users.FirstOrDefault(x => x.Username == user.Username);
            if (existingUser != null)
            {
                return null;
            }

            user.Password = Hash.GenerateHash(user.Password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public IEnumerable<UserAccount> GetAll()
        {
            var query = from Users in _context.Users
                        select Users;
            return query.Select(user => new UserAccount { UserId = user.UserId, Username = user.Username });
        }
    }
}
