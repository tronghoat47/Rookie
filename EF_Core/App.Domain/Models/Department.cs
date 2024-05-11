using System.ComponentModel.DataAnnotations;

namespace App.Domain.Models
{
    public class Department
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [RegularExpression("Hanoi|HCM|Danang")]
        public string Location { get; set; } = "Hanoi";

        public virtual List<Employee>? Employees { get; set; }
    }
}