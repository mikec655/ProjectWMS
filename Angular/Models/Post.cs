using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Angular.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        public int PostUserId { get; set; }

        [ForeignKey("PostUserId")]
        public User User { get; set; }

        public DateTime PostedAt { get; set; }

        [NotMapped]
        public long TimeStamp { get; set; }

        public string Message { get; set; }
    }
}
