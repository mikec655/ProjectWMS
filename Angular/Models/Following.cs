using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Angular.Models
{
    public class Following
    {
        [Key]
        public int FollowId { get; set; }

        public int? FollowingUserId { get; set; }

        public int? FollowingTargetUserId { get; set; }

        [ForeignKey("FollowingUserId")]
        public UserAccount User { get; set; }

        [ForeignKey("FollowingTargetUserId")]
        public UserAccount Target { get; set; }
    }
}
