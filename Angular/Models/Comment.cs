using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Angular.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        public int? CommentPostId { get; set; }

        [ForeignKey("CommentPostId")]
        public Post Post { get; set; }

        public int CommentUserId { get; set; }

        [ForeignKey("CommentUserId")]
        public User User { get; set; }

        public string Content { get; set; }

        public DateTime PostedAt { get; set; }

        [NotMapped]
        public long TimeStamp { get; set; }
    }
}
