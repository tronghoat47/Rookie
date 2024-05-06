using ProjectStructure.Domain;
using ProjectStructure.Domain.Enums;
using ProjectStructure.Repository.IRepository;
using ProjectStucture.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStucture.Application.Services
{
    public class RookieService : IRookieService
    {
        private readonly IPersonRepository _personRepository;
        public RookieService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public List<Person> GetPeople()
        {
            return _personRepository.GetPeople();
        }
        public List<Person> FilterByBirthYear(int year, string comparison)
        {
            return _personRepository.GetPeople().Where(person => comparison == "eq" && person.DateOfBirth.Year == year
                                                    || comparison == "gt" && person.DateOfBirth.Year > year
                                                    || comparison == "lt" && person.DateOfBirth.Year < year)
                                    .ToList();
        }

        public Person GetOldestPerson()
        {
            Person result = _personRepository.GetPeople().OrderBy(p => p.DateOfBirth).FirstOrDefault();
            return result;
        }

        public List<Person> GetPeopleByGender(string gender)
        {
            List<Person> result = _personRepository.GetPeople().Where(p => p.Gender.ToString() == gender).ToList();
            return result;
        }

        public string GetStringResult(List<Person> people, bool isCombinedName)
        {
            string result = "-------------------------------------\n";
            if (people.Count == 0)
            {
                result += "No person found\n";
            }
            else
            {
                result += $"Total persons: {people.Count}\n" +
                    $"---------------------------------------\n";
                foreach (Person person in people)
                {
                    if (!isCombinedName)
                    {
                        result += $"First Name: {person.FirstName}\n" +
                            $"Last Name: {person.LastName}\n";
                    }
                    else
                    {
                        result += $"Full Name: {person.LastName} {person.FirstName}\n";
                    }
                    result += $"Gender: {person.Gender}\n";
                    result += $"Phone Number: {person.PhoneNumber}\n" +
                        $"Date of Birth: {person.DateOfBirth}\n" +
                        $"Place of Birth: {person.BirthPlace}\n" +
                        $"Age: {(DateTime.Now.Year - person.DateOfBirth.Year)}\n" +
                        $"Is Graduated: {person.IsGraduated}\n" +
                        $"-------------------------------------------\n";
                }
            }
            return result;
        }
    }
}
