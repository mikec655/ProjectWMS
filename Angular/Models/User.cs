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

        [Column(TypeName = "varchar(200)")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string Password { get; set; }

        [NotMapped]
        public string Token { get; set; }
    }
}
