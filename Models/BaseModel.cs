using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace cms_api.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        [JsonIgnore]
        [Required]
        public bool IsDeleted { get; set; } = false;
    }
}