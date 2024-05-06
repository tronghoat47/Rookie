using Assignment_MVC_Day1.Common;
using Assignment_MVC_Day1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_MVC_Day1.Controllers
{
    public class RookiesController : Controller
    {
        private List<Person> persons = new List<Person>{
            new Person("Hoa", "Trong", GenderType.male, new DateOnly(1990, 1, 1), "1234567890", "Hanoi", false),
            new Person("Alice", "Johnson", GenderType.female, new DateOnly(1988, 5, 10), "2345678901", "New York", true),
            new Person("Michael", "Williams", GenderType.male, new DateOnly(1985, 9, 15), "3456789012", "Los Angeles", false),
            new Person("Emily", "Brown", GenderType.female, new DateOnly(1992, 3, 20), "4567890123", "Chicago", true),
            new Person("David", "Jones", GenderType.male, new DateOnly(1987, 7, 25), "5678901234", "Houston", false),
            new Person("John", "Smith", GenderType.male, new DateOnly(1995, 2, 12), "6789012345", "Phoenix", true),
            new Person("Sarah", "Martinez", GenderType.female, new DateOnly(1993, 6, 5), "7890123456", "Philadelphia", false),
            new Person("Christopher", "Taylor", GenderType.male, new DateOnly(1989, 10, 8), "8901234567", "San Antonio", true),
            new Person("Emma", "Anderson", GenderType.female, new DateOnly(1991, 4, 17), "9012345678", "San Diego", false),
            new Person("Matthew", "Garcia", GenderType.male, new DateOnly(1986, 8, 29), "0123456789", "Dallas", true),
            new Person("Olivia", "Rodriguez", GenderType.female, new DateOnly(1994, 12, 3), "1234567890", "San Jose", false),
            new Person("James", "Lopez", GenderType.male, new DateOnly(1984, 11, 14), "2345678901", "Austin", true),
            new Person("Sophia", "Wilson", GenderType.female, new DateOnly(1996, 7, 21), "3456789012", "Jacksonville", false),
            new Person("William", "Miller", GenderType.male, new DateOnly(1988, 3, 26), "4567890123", "San Francisco", true),
            new Person("Ava", "Davis", GenderType.female, new DateOnly(1984, 11, 14), "5678901234", "Indianapolis", false),
            new Person("Daniel", "Hernandez", GenderType.male, new DateOnly(1993, 5, 13), "6789012345", "Columbus", true),
            new Person("Charlotte", "White", GenderType.female, new DateOnly(1987, 1, 22), "7890123456", "Fort Worth", false),
            new Person("Alexander", "Gonzalez", GenderType.male, new DateOnly(1985, 6, 18), "8901234567", "Charlotte", true),
            new Person("Isabella", "Moore", GenderType.female, new DateOnly(1992, 8, 9), "9012345678", "Seattle", false),
            new Person("Joseph", "Jackson", GenderType.male, new DateOnly(1989, 4, 5), "0123456789", "Denver", true),
            new Person("Mia", "Thomas", GenderType.female, new DateOnly(1991, 11, 30), "1234567890", "Washington", false)
        };
        private readonly PersonUtils personUtils;
        public RookiesController()
        {
            personUtils = new PersonUtils();
        }
        public IActionResult Index()
        {
            var result = personUtils.GetResult(persons, false);
            return Content(result);
        }

        public IActionResult PeopleByGender(string gender)
        {
            if (!string.IsNullOrEmpty(gender) && Enum.IsDefined(typeof(GenderType), gender))
            {
                var result = personUtils.GetPersonByGender(persons, gender);
                return Content(personUtils.GetResult(result, false));
            }
            return Content("gender is not valid");
        }

        public IActionResult TheOldestPerson()
        {
            var result = personUtils.GetTheOldestPerson(persons);
            return Content(personUtils.GetResult(new List<Person> { result }, false));
        }

        public IActionResult PeopleWithFullName()
        {
            var result = personUtils.GetResult(persons, true);
            return Content(result);
        }

        public IActionResult PeopleByYearOfBirth(string ope, int year)
        {
            var result = personUtils.GetPersonByYearOfBirth(persons, ope, year);
            return Content(personUtils.GetResult(result, false));
        }

    }
}
