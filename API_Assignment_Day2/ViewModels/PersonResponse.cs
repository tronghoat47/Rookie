using ProjectStructure.Domain.Constants;
using ProjectStructure.Domain.Enums;
using ProjectStructure.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace API_Assignment_Day2.ViewModels
{
    public class PersonResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string? BirthPlace { get; set; }
        public bool IsGraduated { get; set; }

        public PersonResponse(Person person)
        {
            Id = person.Id;
            FirstName = person.FirstName;
            LastName = person.LastName;
            Gender = person.Gender.ToString();
            DateOfBirth = person.DateOfBirth;
            PhoneNumber = person.PhoneNumber;
            BirthPlace = person.BirthPlace;
            IsGraduated = person.IsGraduated;
        }
    }
}
