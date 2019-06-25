using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Angular.Models
{
    public class Guest
    {
        [Key]
        public int GuestId { get; set; }

        public int GuestUserId { get; set; }

        [ForeignKey("GuestUserId")]
        public UserAccount User { get; set; }

        public int InvitationId { get; set; }

        [ForeignKey("GuestInvitationId")]
        public Invitation Invitation { get; set; }
    }
}
