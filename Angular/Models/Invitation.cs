using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Angular.Models
{
    public class Invitation
    {
        [Key]
        public int InvitationId { get; set; }

        public int InvitationPostId { get; set; }

        [JsonIgnore]
        [ForeignKey("InvitationPostId")]
        public Post Post { get; set; }

        [JsonIgnore]
        public DateTime PostedAt { get; set; }

        [NotMapped]
        public long PostedAtUnix { get; set; }

        [JsonIgnore]
        [InverseProperty("Invitation")]
        public List<Guest> Guests { get; set; }

        public string Type { get; set; }

        public int NumberOfGuest { get; set; }

        public void ToDto()
        {
            PostedAtUnix = new DateTimeOffset(PostedAt).ToUnixTimeMilliseconds();
        }

        public void ToEntity()
        {
            PostedAt = DateTimeOffset.FromUnixTimeMilliseconds(PostedAtUnix).UtcDateTime;
        }

        public static Expression<Func<Invitation, Invitation>> ReverseProjection
        {
            get
            {
                return p => new Invitation()
                {
                    InvitationId = p.InvitationId,
                    InvitationPostId = p.InvitationPostId,
                    PostedAt = DateTimeOffset.FromUnixTimeMilliseconds(p.PostedAtUnix).UtcDateTime,
                    PostedAtUnix = p.PostedAtUnix,
                    Type = p.Type,
                    NumberOfGuest = p.NumberOfGuest,
                    Post = p.Post
                };
            }
        }

        public static Expression<Func<Invitation, Invitation>> Projection
        {
            get
            {
                return p => new Invitation()
                {
                    InvitationId = p.InvitationId,
                    InvitationPostId = p.InvitationPostId,
                    PostedAtUnix = new DateTimeOffset(p.PostedAt).ToUnixTimeMilliseconds(),
                    Type = p.Type,
                    NumberOfGuest = p.NumberOfGuest,
                    Guests = p.Guests,
                    Post = p.Post,
                    PostedAt = p.PostedAt
            };
            }
        }
    }
}
