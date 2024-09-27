using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace cms_api.Models
{
    public class ProjectTech:AuditModel
    {
        [Required]
        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        [JsonIgnore]
        public Project Project { get; set; }
        [Required]
        public int SkillId { get; set; }
        [ForeignKey("SkillId")]
        [JsonIgnore]
        public Skill Skill { get; set; }
    }
}