using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectStructure.Domain.Enums;

namespace ProjectStructure.Domain.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderType Gender { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthPlace { get; set; }
        public bool IsGraduated { get; set; }

        public Person(string firstName, string lastName, GenderType gender, DateOnly dateOfBirth, string phoneNumber, string birthPlace, bool isGraduated)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            BirthPlace = birthPlace;
            IsGraduated = isGraduated;
        }
    }
}
