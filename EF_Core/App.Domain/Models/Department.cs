using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Models
{
    public class Department
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [RegularExpression("Hanoi|HCM|Danang")]
        public string Location { get; set; }
        public virtual List<Employee>? Employees { get; set; }
    }
}
