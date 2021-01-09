using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cms_api.Models
{
    public class ProjectTech:AuditModel
    {
        [Required]
        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
        [Required]
        public int SkillId { get; set; }
        [ForeignKey("SkillId")]
        public Skill Skill { get; set; }
    }
}