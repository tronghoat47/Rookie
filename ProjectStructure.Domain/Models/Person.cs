using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectStructure.Domain.Constants;
using ProjectStructure.Domain.Enums;
using ProjectStructure.Domain.ViewModels;

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

        public Person(Person person)
        {
            Id = person.Id;
            FirstName = person.FirstName;
            LastName = person.LastName;
            Gender = person.Gender;
            DateOfBirth = person.DateOfBirth;
            PhoneNumber = person.PhoneNumber;
            BirthPlace = person.BirthPlace;
            IsGraduated = person.IsGraduated;
        }

        [NotMapped]
        public List<SelectItem> GraduatedOption = new List<SelectItem>
        {
            new SelectItem { Key = true, Description = "Yes" },
            new SelectItem { Key = false, Description = "No" }
        };

        [NotMapped]
        public List<SelectItem> GenderOption = new List<SelectItem>
        {
            new SelectItem { Key = GenderType.unknown, Description = "Unknown" },
            new SelectItem { Key = GenderType.male, Description = "Male" },
            new SelectItem { Key = GenderType.female, Description = "Female" },
            new SelectItem { Key = GenderType.other, Description = "Other" },
        };
    }
}
