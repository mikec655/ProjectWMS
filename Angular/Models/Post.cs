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
        public UserAccount User { get; set; }

        public DateTime? PostedAt { get; set; }

        [NotMapped]
        public long PostedAtUnix { get; set; }

        public string Message { get; set; }

        public void ToEntity()
        {
            PostedAt = DateTimeOffset.FromUnixTimeMilliseconds(PostedAtUnix).UtcDateTime;
        }

        public void ToDto()
        {
            PostedAtUnix = new DateTimeOffset(PostedAt.Value.ToUniversalTime()).ToUnixTimeMilliseconds();
        }
    }
}
