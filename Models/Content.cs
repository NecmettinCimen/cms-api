using System;
using System.ComponentModel.DataAnnotations;

namespace cms_api.Models
{
    public class Content:AuditModel
    {
        [Required]
        [MaxLength(500)]
        public string Title { get; set; }
        [Required]
        [MaxLength(5000)]
        public string Description { get; set; }
        public DateTime Date { get; set; }
        [MaxLength(100)]
        public string Category { get; set; }
        [Required]
        public ContentStatus Status { get; set; }
    }
    public enum ContentStatus{
        Created,
        Published
    }
}