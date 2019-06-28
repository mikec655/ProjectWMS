using Angular.Utils;
using Swashbuckle.AspNetCore.Examples;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Angular.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class UserAccount
    {
        [Key]
        [Column(TypeName = "int")]
        public int? UserId { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Username { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Password { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Gender { get; set; }

        public DateTime? BirthDate { get; set; }

        [NotMapped]
        public long BirthDateUnix { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public int? UserMediaId { get; set; }

        [ForeignKey("UserMediaId")]
        public Media ProfilePicture { get; set; }

        public string ProfileDescription { get; set; }

        [NotMapped]
        public string Token { get; set; }

        // Since we got 2 navigational properties (relations) with Review define the InverseProperty so it knows which one we want
        [InverseProperty("User")]
        public List<Review> Reviews { get; set; }

        /// <summary>
        /// Convert this to a DTO object ready for transmission
        /// </summary>
        public void ToDto()
        {
            Password = null;

            BirthDateUnix = new DateTimeOffset(BirthDate.Value.ToUniversalTime()).ToUnixTimeMilliseconds();
            BirthDate = null;
        }

        /// <summary>
        /// Convert this to an Entity ready for insertion into database. Doesn't do hashing.
        /// </summary>
        public void ToEntity()
        {
            BirthDate = DateTimeOffset.FromUnixTimeMilliseconds(BirthDateUnix).UtcDateTime;
        }
    }

    public class UserAccountDto : IExamplesProvider
    {
        public int? UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Gender { get; set; }

        public long? BirthDateUnix { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public int? UserMediaId { get; set; }

        public string ProfileDescription { get; set; }

        public string Token { get; set; }

        public static Expression<Func<UserAccount, UserAccountDto>> Projection
        {
            get
            {
                return p => new UserAccountDto()
                {
                    UserId = p.UserId,
                    Username = p.Username,
                    Password = null,
                    Firstname = p.Firstname,
                    Lastname = p.Lastname,
                    Gender = p.Gender,
                    BirthDateUnix = new DateTimeOffset(p.BirthDate.Value.ToUniversalTime()).ToUnixTimeMilliseconds(),
                    Street = p.Street,
                    Number = p.Number,
                    ZipCode = p.ZipCode,
                    City = p.City,
                    UserMediaId = p.UserMediaId,
                    ProfileDescription = p.ProfileDescription,
                    Token = p.Token
            };
            }
        }

        public static Expression<Func<UserAccountDto, UserAccount>> ReverseProjection
        {
            get
            {
                return p => new UserAccount()
                {
                    UserId = p.UserId,
                    Username = p.Username,
                    Password = p.Password,
                    Firstname = p.Firstname,
                    Lastname = p.Lastname,
                    Gender = p.Gender,
                    BirthDate = DateTimeOffset.FromUnixTimeMilliseconds(p.BirthDateUnix.GetValueOrDefault()).UtcDateTime,
                    Street = p.Street,
                    Number = p.Number,
                    ZipCode = p.ZipCode,
                    City = p.City,
                    UserMediaId = p.UserMediaId,
                    ProfileDescription = p.ProfileDescription,
                    Token = p.Token
                };
            }
        }

        public static UserAccountDto FromEntity(UserAccount entity)
        {
            if (entity == null)
                return null;

            return Projection.Compile().Invoke(entity);
        }

        public UserAccount ToEntity()
        {
            return ReverseProjection.Compile().Invoke(this);
        }

        public object GetExamples()
        {
            return new UserAccountDto()
            {
                UserId = 1,
                Username = "Test",
                Firstname = "Jans",
                Lastname = "Jansen",
                Gender = "M",
                BirthDateUnix = 1561511612130,
                Street = "Hoofdkade",
                Number = "155",
                ZipCode = "9503HH",
                City = "Stadskanaal",
                UserMediaId = 1,
                ProfileDescription = "Kaas",
            };
        }
    }
}
