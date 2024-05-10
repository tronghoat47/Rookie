﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Models
{
    public class Project
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [RegularExpression("New|In Progress|Completed")]
        public string Status { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public virtual List<ProjectEmployee>? ProjectEmployees { get; set; }
    }
}
