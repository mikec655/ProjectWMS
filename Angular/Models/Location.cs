using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Angular.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        public int LocationInvitationId { get; set; }

        [ForeignKey("LocationInvitationId")]
        public Invitation Invitation { get; set; }
    }
}
