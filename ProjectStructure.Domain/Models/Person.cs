using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectStructure.Domain.Constants;
using ProjectStructure.Domain.Enums;

namespace ProjectStructure.Domain.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }
        public GenderType Gender { get; set; }
        public DateOnly DateOfBirth { get; set; }
        [RegularExpression(RegrexValidation.PATTERN_PHONE_NUMBER, ErrorMessage = "Phone number must include 10 digits and start 0")]
        public string? PhoneNumber { get; set; }
        public string? BirthPlace { get; set; }
        public bool IsGraduated { get; set; }

        public Person(string firstName, string lastName, GenderType gender, DateOnly dateOfBirth, string phoneNumber, string birthPlace, bool isGraduated)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            BirthPlace = birthPlace;
            IsGraduated = isGraduated;
        }

        public Person()
        {
            Id = Guid.NewGuid();
        }
    }
}
