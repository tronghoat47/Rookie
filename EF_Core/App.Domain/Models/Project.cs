using System.ComponentModel.DataAnnotations;

namespace App.Domain.Models
{
    public class Project
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [RegularExpression("New|In Progress|Completed")]
        public string Status { get; set; } = "New";

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        public virtual List<ProjectEmployee>? ProjectEmployees { get; set; }
    }
}