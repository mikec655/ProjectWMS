using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
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
        public UserAccount User { get; set; }

        public string Content { get; set; }

        public DateTime PostedAt { get; set; }

        public CommentDto Project()
        {
            return CommentDto.Projection.Compile().Invoke(this);
        }
    }

    //Data transfer Object used for conversion between ASP.NET and Angular
    public class CommentDto
    {
        public int CommentId { get; set; }

        public int? CommentPostId { get; set; }

        public int CommentUserId { get; set; }

        public string UserFirstName { get; set; }

        public string UserLastName { get; set; }

        public string Content { get; set; }

        public long PostedAtUnix { get; set; }

        public static Expression<Func<Comment, CommentDto>> Projection
        {
            get
            {
                return p => new CommentDto()
                {
                    CommentId = p.CommentId,
                    CommentPostId = p.CommentPostId,
                    CommentUserId = p.CommentUserId,
                    UserFirstName = p.User.Firstname,
                    UserLastName = p.User.Lastname,
                    Content = p.Content,
                    PostedAtUnix = new DateTimeOffset(p.PostedAt).ToUnixTimeMilliseconds()
                };
            }
        }

        public static Expression<Func<CommentDto, Comment>> ReverseProjection
        {
            get
            {
                return p => new Comment()
                {
                    CommentId = p.CommentId,
                    CommentPostId = p.CommentPostId,
                    CommentUserId = p.CommentUserId,
                    Content = p.Content,
                    PostedAt = DateTimeOffset.FromUnixTimeMilliseconds(p.PostedAtUnix).UtcDateTime
                };
            }
        }

        public static CommentDto FromEntity(Comment entity)
        {
            if (entity == null)
                return null;

            return Projection.Compile().Invoke(entity);
        }

        public Comment ToEntity()
        {
            return ReverseProjection.Compile().Invoke(this);
        }
    }
}
