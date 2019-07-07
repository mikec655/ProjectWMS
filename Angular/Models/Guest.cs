using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Angular.Models
{
    public class Guest
    {
        [Key]
        public int GuestId { get; set; }

        public int GuestUserId { get; set; }

        [ForeignKey("GuestUserId")]
        public UserAccount User { get; set; }

        public int GuestInvitationId { get; set; }

        [JsonIgnore]
        [ForeignKey("GuestInvitationId")]
        public Invitation Invitation { get; set; }
    }
}
