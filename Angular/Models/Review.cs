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
        public int ReviewId { get; set; }

        public short Rating { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }

        public int ReviewTargetId { get; set; }

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
    }
}
