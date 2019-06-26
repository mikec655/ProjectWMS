using Angular.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Angular.Models
{
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

        public int Number { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string ProfilePicture { get; set; }

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
}
