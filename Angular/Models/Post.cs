using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
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

    public class PostDto
    {
        public int PostId { get; set; }

        public int PostUserId { get; set; }

        public string UserFirstName { get; set; }

        public string UserLastName { get; set; }

        public long PostedAtUnix { get; set; }

        public string Message { get; set; }

        /// <summary>
        /// Convert given Post to a DTO object. Include User for correct operation
        /// </summary>
        public static Expression<Func<Post, PostDto>> Projection
        {
            get
            {
                return p => new PostDto()
                {
                    PostId = p.PostId,
                    PostUserId = p.PostUserId,
                    UserFirstName = p.User == null ? null : p.User.Firstname,
                    UserLastName = p.User == null ? null : p.User.Lastname,
                    Message = p.Message,
                    PostedAtUnix = new DateTimeOffset(p.PostedAt.HasValue ? p.PostedAt.Value : DateTime.UtcNow).ToUnixTimeMilliseconds()
                };
            }
        }

        public static Expression<Func<PostDto, Post>> ReverseProjection
        {
            get
            {
                return p => new Post()
                {
                    PostId = p.PostId,
                    PostUserId = p.PostUserId,
                    Message = p.Message,
                    PostedAt = DateTimeOffset.FromUnixTimeMilliseconds(p.PostedAtUnix).UtcDateTime
                };
            }
        }

        public static PostDto FromEntity(Post entity)
        {
            if (entity == null)
                return null;

            return Projection.Compile().Invoke(entity);
        }

        public Post ToEntity()
        {
            return ReverseProjection.Compile().Invoke(this);
        }
    }

}
