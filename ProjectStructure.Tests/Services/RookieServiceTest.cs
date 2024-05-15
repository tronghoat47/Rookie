using Moq;
using ProjectStructure.Domain.Enums;
using ProjectStructure.Domain.Models;
using ProjectStructure.Repository.IRepository;
using ProjectStucture.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjectStructure.Tests.Services
{
    public class RookieServiceTest
    {
        private readonly Mock<IPersonRepository> _mockPersonRepo;
        private readonly RookieService _rookieService;

        public RookieServiceTest()
        {
            _mockPersonRepo = new Mock<IPersonRepository>();
            _rookieService = new RookieService(_mockPersonRepo.Object);
        }

        [Fact]
        public void GetPeople_ReturnsPeople()
        {
            // Arrange
            var people = new List<Person>
            {
                new Person { FirstName = "John", LastName = "Doe", DateOfBirth = new DateOnly(1990, 1, 1)}
            };
            _mockPersonRepo.Setup(repo => repo.GetPeople()).Returns(people);

            // Act
            var result = _rookieService.GetPeople();
            // Assert
            Assert.Equal(people, result);
        }

        [Fact]
        public void FilterByBirthYear_ComparisonIsGreaterThan_ReturnsFilteredPeople()
        {
            // Arrange
            var people = new List<Person>
            {
                new Person { FirstName = "John", LastName = "Doe", DateOfBirth = new DateOnly(1990, 1, 1)},
                new Person { FirstName = "Jane", LastName = "Doe", DateOfBirth = new DateOnly(1995, 1, 1)},
                new Person { FirstName = "Jack", LastName = "Doe", DateOfBirth = new DateOnly(2000, 1, 1)}
            };
            _mockPersonRepo.Setup(repo => repo.GetPeople()).Returns(people);

            // Act
            var result = _rookieService.FilterByBirthYear(1995, "gt");

            // Assert
            Assert.Equal(1, result.Count);
        }

        [Fact]
        public void FilterByBirthYear_ComparisonIsLessThan_ReturnsFilteredPeople()
        {
            // Arrange
            var people = new List<Person>
            {
                new Person { FirstName = "John", LastName = "Doe", DateOfBirth = new DateOnly(1990, 1, 1)},
                new Person { FirstName = "Jane", LastName = "Doe", DateOfBirth = new DateOnly(1995, 1, 1)},
                new Person { FirstName = "Jack", LastName = "Doe", DateOfBirth = new DateOnly(2000, 1, 1)}
            };
            _mockPersonRepo.Setup(repo => repo.GetPeople()).Returns(people);

            // Act
            var result = _rookieService.FilterByBirthYear(1995, "lt");

            // Assert
            Assert.Equal(1, result.Count);
        }

        [Fact]
        public void FilterByBirthYear_ComparisonIsEqual_ReturnsFilteredPeople()
        {
            // Arrange
            var people = new List<Person>
            {
                new Person { FirstName = "John", LastName = "Doe", DateOfBirth = new DateOnly(1990, 1, 1)},
                new Person { FirstName = "Jane", LastName = "Doe", DateOfBirth = new DateOnly(1995, 1, 1)},
                new Person { FirstName = "Jack", LastName = "Doe", DateOfBirth = new DateOnly(2000, 1, 1)}
            };
            _mockPersonRepo.Setup(repo => repo.GetPeople()).Returns(people);

            // Act
            var result = _rookieService.FilterByBirthYear(1995, "eq");

            // Assert
            Assert.Equal(1, result.Count);
        }

        [Fact]
        public void GetOldestPerson_ReturnsOldestPerson()
        {
            // Arrange
            var people = new List<Person>
            {
                new Person { FirstName = "John", LastName = "Doe", DateOfBirth = new DateOnly(1990, 1, 1)},
                new Person { FirstName = "Jane", LastName = "Doe", DateOfBirth = new DateOnly(1995, 1, 1)},
                new Person { FirstName = "Jack", LastName = "Doe", DateOfBirth = new DateOnly(2000, 1, 1)}
            };
            _mockPersonRepo.Setup(repo => repo.GetPeople()).Returns(people);

            // Act
            var result = _rookieService.GetOldestPerson();

            // Assert
            Assert.Equal(people[0], result);
        }

        [Fact]
        public void GetPeopleByGender_ReturnsPeopleByGender()
        {
            // Arrange
            var people = new List<Person>
            {
                new Person { FirstName = "John", LastName = "", Gender=GenderType.male},
                new Person { FirstName = "Jane", LastName = "", Gender=GenderType.male},
                new Person { FirstName = "Jack", LastName ="", Gender=GenderType.female}
            };
            _mockPersonRepo.Setup(repo => repo.GetPeople()).Returns(people);

            // Act
            var result = _rookieService.GetPeopleByGender("male");

            // Assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void GetStringResult_CombinedName_ReturnsStringResult()
        {
            // Arrange
            var people = new List<Person>
            {
                new Person { FirstName = "John", LastName = "", Gender=GenderType.male},
                new Person { FirstName = "Jane", LastName = "", Gender=GenderType.male},
                new Person { FirstName = "Jack", LastName ="", Gender=GenderType.female}
            };

            // Act
            var result = _rookieService.GetStringResult(people, true);

            // Assert
            Assert.Contains("Full Name: ", result);
        }

        [Fact]
        public void GetStringResult_NotCombinedName_ReturnsStringResult()
        {
            // Arrange
            var people = new List<Person>
            {
                new Person { FirstName = "John", LastName = "", Gender=GenderType.male},
                new Person { FirstName = "Jane", LastName = "", Gender=GenderType.male},
                new Person { FirstName = "Jack", LastName ="", Gender=GenderType.female}
            };

            // Act
            var result = _rookieService.GetStringResult(people, false);

            // Assert
            Assert.DoesNotContain("Full Name: ", result);
        }

        [Fact]
        public void GetStringResult_NoData_ReturnsStringResult()
        {
            // Arrange
            var people = new List<Person>();

            // Act
            var result = _rookieService.GetStringResult(people, false);

            // Assert
            Assert.Contains("No person found", result);
        }

        [Fact]
        public void GetPersonById_ReturnsPerson()
        {
            // Arrange
            var person = new Person { Id = Guid.NewGuid(), FirstName = "John", LastName = "Doe" };
            _mockPersonRepo.Setup(repo => repo.GetPersonById(person.Id)).Returns(person);

            // Act
            var result = _rookieService.GetPersonById(person.Id);

            // Assert
            Assert.Equal(person, result);
        }

        [Fact]
        public void AddPerson_PersonExists_ReturnsNull()
        {
            // Arrange
            var person = new Person { Id = Guid.NewGuid(), FirstName = "John", LastName = "Doe" };
            _mockPersonRepo.Setup(repo => repo.GetPersonById(person.Id)).Returns(person);

            // Act
            var result = _rookieService.AddPerson(person);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void AddPerson_PersonDoesNotExist_ReturnsPerson()
        {
            // Arrange
            var person = new Person { Id = Guid.NewGuid(), FirstName = "John", LastName = "Doe" };
            _mockPersonRepo.Setup(repo => repo.GetPersonById(person.Id)).Returns((Person)null);
            _mockPersonRepo.Setup(repo => repo.AddPerson(person)).Returns(person);

            // Act
            var result = _rookieService.AddPerson(person);

            // Assert
            Assert.Equal(person, result);
        }

        [Fact]
        public void UpdatePerson_PersonExists_ReturnsPerson()
        {
            // Arrange
            var person = new Person { Id = Guid.NewGuid(), FirstName = "John", LastName = "Doe" };
            _mockPersonRepo.Setup(repo => repo.GetPersonById(person.Id)).Returns(person);
            _mockPersonRepo.Setup(repo => repo.UpdatePerson(person)).Returns(person);

            // Act
            var result = _rookieService.UpdatePerson(person);

            // Assert
            Assert.Equal(person, result);
        }

        [Fact]
        public void UpdatePerson_PersonDoesNotExist_ReturnsNull()
        {
            // Arrange
            var person = new Person { Id = Guid.NewGuid(), FirstName = "John", LastName = "Doe" };
            _mockPersonRepo.Setup(repo => repo.GetPersonById(person.Id)).Returns((Person)null);

            // Act
            var result = _rookieService.UpdatePerson(person);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void DeletePerson_PersonExists_ReturnsPerson()
        {
            // Arrange
            var person = new Person { Id = Guid.NewGuid(), FirstName = "John", LastName = "Doe" };
            _mockPersonRepo.Setup(repo => repo.GetPersonById(person.Id)).Returns(person);
            _mockPersonRepo.Setup(repo => repo.DeletePerson(person.Id)).Returns(person);

            // Act
            var result = _rookieService.DeletePerson(person.Id);

            // Assert
            Assert.Equal(person, result);
        }

        [Fact]
        public void DeletePerson_PersonDoesNotExist_ReturnsNull()
        {
            // Arrange
            var person = new Person { Id = Guid.NewGuid(), FirstName = "John", LastName = "Doe" };
            _mockPersonRepo.Setup(repo => repo.GetPersonById(person.Id)).Returns((Person)null);

            // Act
            var result = _rookieService.DeletePerson(person.Id);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void FilterPeople_IncludeGender_ReturnsFilteredPeople()
        {
            // Arrange
            var people = new List<Person>
            {
                new Person { FirstName = "John", LastName = "", Gender=GenderType.male, BirthPlace ="HN"},
                new Person { FirstName = "Jane", LastName = "", Gender=GenderType.male, BirthPlace ="HN"},
                new Person { FirstName = "Jack", LastName ="", Gender=GenderType.female, BirthPlace ="HN"}
            };
            _mockPersonRepo.Setup(repo => repo.GetPeople()).Returns(people);

            // Act
            var result = _rookieService.FilterPeople("John", GenderType.male, "HN");

            // Assert
            Assert.Equal(1, result.Count);
        }

        [Fact]
        public void FilterPeople_NotIncludeGender_ReturnsFilteredPeople()
        {
            // Arrange
            var people = new List<Person>
            {
                new Person { FirstName = "John", LastName = "", Gender=GenderType.male, BirthPlace ="HN"},
                new Person { FirstName = "Jane", LastName = "", Gender=GenderType.male, BirthPlace ="HN"},
                new Person { FirstName = "Jack", LastName ="", Gender=GenderType.female, BirthPlace ="HN"}
            };
            _mockPersonRepo.Setup(repo => repo.GetPeople()).Returns(people);

            // Act
            var result = _rookieService.FilterPeople("John", "HN");

            // Assert
            Assert.Equal(1, result.Count);
        }
    }
}