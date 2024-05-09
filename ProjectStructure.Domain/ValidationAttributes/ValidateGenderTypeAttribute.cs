using ProjectStructure.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStructure.Domain.ValidationAttributes
{
    public class ValidGenderTypeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && Enum.TryParse(typeof(GenderType), value.ToString(), true, out _))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Invalid gender type");
            }
        }
    }
}
