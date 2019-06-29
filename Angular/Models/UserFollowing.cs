using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Angular.Models
{
    public class UserFollowing
    {
        [Key]
        public int FollowId { get; set; }

        [ForeignKey("User")]
        public int FollowingUserAccountId { get; set; }
        
        [ForeignKey("Target")]
        public int FollowingUserAccountTargetId { get; set; }

        [ForeignKey("FollowingUserAccountId")]
        public UserAccount User { get; set; }

        [ForeignKey("FollowingUserAccountTargetId")]
        public UserAccount Target { get; set; }
    }
}
