using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Models
{
    public class Employee
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [MaxLength(100)]
        public string Address { get; set; }
        [Required]
        [MaxLength(100)]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string Email { get; set; }
        [Required]
        [MaxLength(100)]
        public string Phone { get; set; }
        [Required]
        public DateTime JoinDate { get; set; }
        [Required]
        public long DepartmentId { get; set; }
        public Department Department { get; set; }
        public Salary Salary { get; set; }
        public virtual List<ProjectEmployee>? ProjectEmployees { get; set; }
    }
}
