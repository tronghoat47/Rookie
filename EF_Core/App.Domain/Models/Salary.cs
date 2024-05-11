using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Models
{
    public class Salary
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        [Required]
        public long EmployeeId { get; set; }

        public Employee? Employee { get; set; }
    }
}