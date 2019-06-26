using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Angular.Models
{
    public class Review
    {
        [Key]
        public int? ReviewId { get; set; }

        public short Rating { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }

        public int ReviewTargetId { get; set; }

        [JsonIgnore]
        public DateTime? PostedAt { get; set; }

        [NotMapped]
        public long PostedAtUnix { get; set; }

        /// <summary>
        /// The person being reviewed (Target of this review)
        /// </summary>
        [ForeignKey("ReviewTargetId")]
        public UserAccount Target { get; set; }

        public int ReviewUserId { get; set; }

        /// <summary>
        /// The person who posted the review
        /// </summary>
        [ForeignKey("ReviewUserId")]
        public UserAccount User { get; set; }

        public void ToDto()
        {
            PostedAtUnix = new DateTimeOffset(PostedAt.Value.ToUniversalTime()).ToUnixTimeMilliseconds();
        }

        public Review ToDtoClone()
        {
            return new Review
            {
                ReviewId = ReviewId,
                Rating = Rating,
                Description = Description,
                ReviewTargetId = ReviewTargetId,
                PostedAtUnix = new DateTimeOffset(PostedAt.Value.ToUniversalTime()).ToUnixTimeMilliseconds(),
                ReviewUserId = ReviewUserId
            };
        }

        public void ToEntity()
        {
            PostedAt = DateTimeOffset.FromUnixTimeMilliseconds(PostedAtUnix).UtcDateTime;
        }
    }
}
