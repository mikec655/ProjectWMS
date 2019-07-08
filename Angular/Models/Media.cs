using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Angular.Models
{
    public class Media
    {
        [Key]
        public int MediaId { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Type { get; set; }

        public int? MediaUserAccountId { get; set; }

        [ForeignKey("MediaUserAccountId")]
        [JsonIgnore]
        public UserAccount User { get; set; }
        
        public byte[] ImageData { get; set; }
    }
}
