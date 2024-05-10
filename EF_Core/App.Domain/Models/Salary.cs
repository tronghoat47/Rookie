using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Models
{
    public class Salary
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public int Amount { get; set; }
        [Required]
        public long EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
