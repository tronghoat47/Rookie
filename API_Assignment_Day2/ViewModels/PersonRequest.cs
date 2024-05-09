using ProjectStructure.Domain.Constants;
using ProjectStructure.Domain.Enums;
using ProjectStructure.Domain.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace API_Assignment_Day2.ViewModels
{
    public class PersonRequest
    {
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }
        [ValidGenderType]
        public string Gender { get; set; }
        [ValidateDateOnlyAttributes]
        public string DateOfBirth { get; set; }
        [RegularExpression(RegrexValidation.PATTERN_PHONE_NUMBER, ErrorMessage = "Phone number must include 10 digits and start 0")]
        public string? PhoneNumber { get; set; }
        public string? BirthPlace { get; set; }
        public bool IsGraduated { get; set; }
    }
}
