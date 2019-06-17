using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Angular.Models
{
    public class Invitation
    {
        [Key]
        public int InvitationId { get; set; }

        public int InvitationPostId { get; set; }

        [ForeignKey("InvitationPostId")]
        public Post Post { get; set; }

        public DateTime Time { get; set; }

        public string Type { get; set; }

        public int NumberOfGuest { get; set; }
    }
}
