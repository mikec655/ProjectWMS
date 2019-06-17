using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Angular.Models
{
    public class User
    {
        [Key]
        [Column(TypeName = "int")]
        public int UserId { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Username { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Password { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Gender { get; set; }

        public DateTime BirthData { get; set; }

        public int More { get; set; }

        [NotMapped]
        public string Token { get; set; }

        // Since we got 2 navigational properties (relations) with Review define the InverseProperty so it knows which one we want
        [InverseProperty("User")]
        public List<Review> Reviews { get; set; }
    }
}
