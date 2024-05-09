using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStructure.Domain.ValidationAttributes
{
    public class ValidateDateOnlyAttributes : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && DateTime.TryParse(value.ToString(), out DateTime date))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Invalid date format");
            }
        }
    }
}
