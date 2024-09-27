using System;
using System.ComponentModel.DataAnnotations;

namespace cms_api.Models
{
    public class Project:AuditModel
    {
        [Required]
        [MaxLength(100)]
        public string Type { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        [MaxLength(500)]
        public string Link { get; set; }
    }
}