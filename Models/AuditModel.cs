using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace cms_api.Models
{
    public class AuditModel:BaseModel
    {
        [JsonIgnore]
        [Required]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [JsonIgnore]
        [Required]
        public int CreatedUserId { get; set; }=1;
        [JsonIgnore]
        [ForeignKey("CreatedUserId")]
        public User CreatedUser { get; set; }
        [JsonIgnore]
        public DateTime? UpdateDate { get; set; } = DateTime.Now;
        [JsonIgnore]
        public int? UpdatedUserId { get; set; }
        [JsonIgnore]
        [ForeignKey("UpdatedUserId")]
        public User UpdatedUser { get; set; }
        [JsonIgnore]
        public DateTime? DeleteDate { get; set; } = DateTime.Now;
        [JsonIgnore]
        public int? DeletedUserId { get; set; }
        [ForeignKey("DeletedUserId")]
        [JsonIgnore]
        public User DeletedUser { get; set; }

    }
}