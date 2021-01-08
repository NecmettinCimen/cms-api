using System;
using System.ComponentModel.DataAnnotations;

namespace cms_api.Models
{
    public class Experience:AuditModel
    {
        [Required]
        [MaxLength(100)]
        public string Type { get; set; }

        [Required]
        [MaxLength(500)]
        public string Name { get; set; }
        [Required]
        [MaxLength(5000)]
        public string Description { get; set; }
        [Required]
        [MaxLength(500)]
        public string Organization { get; set; }
        [Required]
        [MaxLength(500)]
        public string OrganizationLink { get; set; }
        [Required]
        public DateTime StartingDate { get; set; }
        public DateTime? DueDate { get; set; }

    }
}