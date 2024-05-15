using Xunit;
using Moq;
using ProjectStructure.Domain.Models;
using ProjectStructure.Domain.Enums;
using ProjectStructure.MVC_Day1.Areas.NashTech.Controllers;
using ProjectStucture.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ProjectStructure.Tests.Controllers
{
    public class RookieControllerTests
    {
        private readonly Mock<IRookieService> _mockRookieService;
        private readonly Mock<IExcelService> _excelService;
        private readonly RookieController _rookieController;

        public RookieControllerTests()
        {
            _mockRookieService = new Mock<IRookieService>();
            _excelService = new Mock<IExcelService>();
            _rookieController = new RookieController(_mockRookieService.Object, _excelService.Object);
        }

        private List<Person> GetTestPeople()
        {
            return new List<Person>
        {
            new Person { Id = Guid.NewGuid(), FirstName = "John", LastName = "Doe", Gender = GenderType.male, DateOfBirth = new DateOnly(1990, 1, 1), PhoneNumber = "0123456789", BirthPlace = "New York", IsGraduated = true },
            new Person { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Doe", Gender = GenderType.female, DateOfBirth = new DateOnly(1991, 2, 2), PhoneNumber = "0987654321", BirthPlace = "Los Angeles", IsGraduated = false },
            new Person { Id = Guid.NewGuid(), FirstName = "Jim", LastName = "Beam", Gender = GenderType.male, DateOfBirth = new DateOnly(1992, 3, 3), PhoneNumber = "0112233445", BirthPlace = "Chicago", IsGraduated = true },
            new Person { Id = Guid.NewGuid(), FirstName = "Jack", LastName = "Daniels", Gender = GenderType.male, DateOfBirth = new DateOnly(1993, 4, 4), PhoneNumber = "0556677889", BirthPlace = "Houston", IsGraduated = false }
        };
        }

        [Fact]
        public void Index_FirstPage_ReturnsFirstPageOfPeople()
        {
            var testPeople = GetTestPeople();
            _mockRookieService.Setup(s => s.GetPeople()).Returns(testPeople);

            int page = 1;
            int pageSize = 2;

            var result = _rookieController.Index(page, pageSize) as ViewResult;
            var model = result.Model as List<Person>;

            Assert.Equal(2, model.Count);
            Assert.Equal("John", model[0].FirstName);
            Assert.Equal("Jane", model[1].FirstName);
        }

        [Fact]
        public void Index_SecondPage_ReturnsSecondPageOfPeople()
        {
            var testPeople = GetTestPeople();
            _mockRookieService.Setup(s => s.GetPeople()).Returns(testPeople);

            int page = 2;
            int pageSize = 2;

            var result = _rookieController.Index(page, pageSize) as ViewResult;
            var model = result.Model as List<Person>;

            Assert.Equal(2, model.Count);
            Assert.Equal("Jim", model[0].FirstName);
            Assert.Equal("Jack", model[1].FirstName);
        }

        //unit test for PeopleByGender
        [Fact]
        public void PeopleByGender_ValidGender_FirstLoad_ReturnsViewWithPeople()
        {
            // Arrange
            var gender = GenderType.male.ToString();
            var people = new List<Person> { new Person { FirstName = "John" } };
            _mockRookieService.Setup(service => service.GetPeopleByGender(gender)).Returns(people);

            // Act
            var result = _rookieController.PeopleByGender(gender, true) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(people, result.Model);
        }

        [Fact]
        public void PeopleByGender_ValidGender_NotFirstLoad_ReturnsPartialViewWithPeople()
        {
            // Arrange
            var gender = GenderType.male.ToString();
            var people = new List<Person> { new Person { FirstName = "John" } };
            _mockRookieService.Setup(service => service.GetPeopleByGender(gender)).Returns(people);

            // Act
            var result = _rookieController.PeopleByGender(gender, false) as PartialViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("_TablePeople", result.ViewName);
            Assert.Equal(people, result.Model);
        }

        [Fact]
        public void PeopleByGender_ValidGender_NoPeopleFound_ReturnsPartialViewWithError()
        {
            // Arrange
            var gender = GenderType.male.ToString();
            _mockRookieService.Setup(service => service.GetPeopleByGender(gender)).Returns(new List<Person>());

            // Act
            var result = _rookieController.PeopleByGender(gender, false) as PartialViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("_TablePeople", result.ViewName);
            Assert.Empty((List<Person>)result.Model);
            Assert.Equal("No person found", _rookieController.ViewBag.Error);
        }

        [Fact]
        public void PeopleByGender_InvalidGender_ReturnsPartialViewWithError()
        {
            // Arrange
            var gender = "InvalidGender";

            // Act
            var result = _rookieController.PeopleByGender(gender, false) as PartialViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("_TablePeople", result.ViewName);
            Assert.Empty((List<Person>)result.Model);
            Assert.Equal("Gender is not valid", _rookieController.ViewBag.Error);
        }

        [Fact]
        public void PeopleByGender_EmptyGender_ReturnsPartialViewWithError()
        {
            // Arrange
            string gender = string.Empty;

            // Act
            var result = _rookieController.PeopleByGender(gender, false) as PartialViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("_TablePeople", result.ViewName);
            Assert.Empty((List<Person>)result.Model);
            Assert.Equal("Gender is not valid", _rookieController.ViewBag.Error);
        }

        [Fact]
        public void TheOldestPerson_PersonExists_ReturnsRedirectToDetailWithId()
        {
            // Arrange
            var person = new Person { Id = Guid.NewGuid(), FirstName = "John" };
            _mockRookieService.Setup(service => service.GetOldestPerson()).Returns(person);

            // Act
            var result = _rookieController.TheOldestPerson() as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Detail", result.ActionName);
            Assert.Equal(person.Id, result.RouteValues["id"]);
        }

        [Fact]
        public void TheOldestPerson_PersonDoesNotExist_ReturnsRedirectToDetail()
        {
            // Arrange
            _mockRookieService.Setup(service => service.GetOldestPerson()).Returns((Person)null);

            // Act
            var result = _rookieController.TheOldestPerson() as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Detail", result.ActionName);
            Assert.Null(result.RouteValues);
        }

        [Fact]
        public void PeopleWithFullName_PeopleExist_ReturnsViewWithPeople()
        {
            // Arrange
            var people = GetTestPeople();
            _mockRookieService.Setup(service => service.GetPeople()).Returns(people);

            // Act
            var result = _rookieController.PeopleWithFullName() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Null(_rookieController.ViewBag.IsNotElement);
            Assert.NotNull(result.Model);
        }

        [Fact]
        public void PeopleWithFullName_NoPeopleFound_ReturnsViewWithError()
        {
            // Arrange
            _mockRookieService.Setup(service => service.GetPeople()).Returns(new List<Person>());

            // Act
            var result = _rookieController.PeopleWithFullName() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("No person found", _rookieController.ViewBag.IsNoElement);
            Assert.Null(result.Model);
        }

        [Fact]
        public void PeopleByYearOfBirth_ValidYearAndOperator_FirstLoad_ReturnsViewWithPeople()
        {
            // Arrange
            var year = "1990";
            var ope = ComparisionOperator.eq.ToString();
            var people = new List<Person> { new Person { FirstName = "John" } };
            _mockRookieService.Setup(service => service.FilterByBirthYear(1990, ope)).Returns(people);

            // Act
            var result = _rookieController.PeopleByYearOfBirth(ope, year, true) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(people, result.Model);
            Assert.Equal(year, _rookieController.ViewBag.Year);
        }

        [Fact]
        public void PeopleByYearOfBirth_ValidYearAndOperator_NotFirstLoad_ReturnsPartialViewWithPeople()
        {
            // Arrange
            var year = "1990";
            var ope = ComparisionOperator.eq.ToString();
            var people = new List<Person> { new Person { FirstName = "John" } };
            _mockRookieService.Setup(service => service.FilterByBirthYear(1990, ope)).Returns(people);

            // Act
            var result = _rookieController.PeopleByYearOfBirth(ope, year, false) as PartialViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("_TablePeople", result.ViewName);
            Assert.Equal(people, result.Model);
        }

        [Fact]
        public void PeopleByYearOfBirth_ValidYearAndOperator_NoPeopleFound_ReturnsPartialViewWithError()
        {
            // Arrange
            var year = "1990";
            var ope = ComparisionOperator.eq.ToString();
            _mockRookieService.Setup(service => service.FilterByBirthYear(1990, ope)).Returns(new List<Person>());

            // Act
            var result = _rookieController.PeopleByYearOfBirth(ope, year, false) as PartialViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("_TablePeople", result.ViewName);
            Assert.Empty((List<Person>)result.Model);
            Assert.Equal("No person found", _rookieController.ViewBag.IsNoElement);
        }

        [Fact]
        public void PeopleByYearOfBirth_InvalidYear_ReturnsPartialViewWithError()
        {
            // Arrange
            var year = "InvalidYear";
            var ope = ComparisionOperator.eq.ToString();

            // Act
            var result = _rookieController.PeopleByYearOfBirth(ope, year, false) as PartialViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("_TablePeople", result.ViewName);
            Assert.Empty((List<Person>)result.Model);
            Assert.Equal("Invalid input", _rookieController.ViewBag.Error);
        }

        [Fact]
        public void PeopleByYearOfBirth_InvalidOperator_ReturnsPartialViewWithError()
        {
            // Arrange
            var year = "1990";
            var ope = "InvalidOperator";

            // Act
            var result = _rookieController.PeopleByYearOfBirth(ope, year, false) as PartialViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("_TablePeople", result.ViewName);
            Assert.Empty((List<Person>)result.Model);
            Assert.Equal("Invalid input", _rookieController.ViewBag.Error);
        }

        [Fact]
        public void ExcelExport_PeopleExist_ReturnsFileResult()
        {
            // Arrange
            var people = GetTestPeople();
            _mockRookieService.Setup(service => service.GetPeople()).Returns(people);

            // Act
            var result = _rookieController.ExportToExcel() as FileResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", result.ContentType);
            Assert.Equal("people.xlsx", result.FileDownloadName);
        }

        [Fact]
        public void Add_ReturnsView()
        {
            // Act
            var result = _rookieController.Add() as ViewResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Add_InvalidModelState_ReturnsView()
        {
            // Arrange
            _rookieController.ModelState.AddModelError("FirstName", "FirstName is required");

            // Act
            var result = _rookieController.Add(new Person()) as ViewResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Add_ValidModelState_AddSuccessful_ReturnsRedirectToIndex()
        {
            // Arrange
            var person = new Person { FirstName = "John" };
            _mockRookieService.Setup(service => service.AddPerson(person)).Returns(person);

            // Act
            var result = _rookieController.Add(person) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public void Add_ValidModelState_AddFailed_ReturnsViewWithMessage()
        {
            // Arrange
            var person = new Person { FirstName = "John" };
            _mockRookieService.Setup(service => service.AddPerson(person)).Returns((Person)null);

            // Act
            var result = _rookieController.Add(person) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Add failed", _rookieController.ViewBag.Message);
        }

        [Fact]
        public void Detail_PersonExists_ReturnsViewWithPerson()
        {
            // Arrange
            var person = new Person { Id = Guid.NewGuid(), FirstName = "John" };
            _mockRookieService.Setup(service => service.GetPersonById(person.Id)).Returns(person);

            // Act
            var result = _rookieController.Detail(person.Id) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(person, result.Model);
        }

        [Fact]
        public void Detail_PersonDoesNotExist_ReturnsViewWithError()
        {
            // Arrange
            var id = Guid.NewGuid();
            _mockRookieService.Setup(service => service.GetPersonById(id)).Returns((Person)null);

            // Act
            var result = _rookieController.Detail(id) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Person not found", _rookieController.ViewBag.Error);
        }

        [Fact]
        public void Edit_PersonExists_ReturnsViewWithPerson()
        {
            // Arrange
            var person = new Person { Id = Guid.NewGuid(), FirstName = "John" };
            _mockRookieService.Setup(service => service.GetPersonById(person.Id)).Returns(person);

            // Act
            var result = _rookieController.Edit(person.Id) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(person, result.Model);
        }

        [Fact]
        public void Edit_PersonDoesNotExist_ReturnsRedirectToIndex()
        {
            // Arrange
            var id = Guid.NewGuid();
            _mockRookieService.Setup(service => service.GetPersonById(id)).Returns((Person)null);

            // Act
            var result = _rookieController.Edit(id) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public void Edit_InvalidModelState_ReturnsView()
        {
            // Arrange
            _rookieController.ModelState.AddModelError("FirstName", "FirstName is required");

            // Act
            var result = _rookieController.Edit(new Person()) as ViewResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Edit_ValidModelState_UpdateSuccessful_ReturnsRedirectToIndex()
        {
            // Arrange
            var person = new Person { Id = Guid.NewGuid(), FirstName = "John" };
            _mockRookieService.Setup(service => service.UpdatePerson(person)).Returns(person);

            // Act
            var result = _rookieController.Edit(person) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public void Edit_ValidModelState_UpdateFailed_ReturnsRedirectToEditWithId()
        {
            // Arrange
            var person = new Person { Id = Guid.NewGuid(), FirstName = "John" };
            _mockRookieService.Setup(service => service.UpdatePerson(person)).Returns((Person)null);

            // Act
            var result = _rookieController.Edit(person) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Edit", result.ActionName);
        }

        [Fact]
        public void Delete_PersonExists_ReturnsRedirectToIndex()
        {
            // Arrange
            var person = new Person { Id = Guid.NewGuid(), FirstName = "John" };
            _mockRookieService.Setup(service => service.DeletePerson(person.Id)).Returns(person);

            // Act
            var result = _rookieController.Delete(person.Id) as JsonResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Delete_PersonNotExist_ReturnsRedirectToIndex()
        {
            var person = new Person { Id = Guid.NewGuid(), FirstName = "John" };
            _mockRookieService.Setup(service => service.DeletePerson(person.Id)).Returns((Person)null);

            // Act
            var result = _rookieController.Delete(person.Id) as JsonResult;
            // Assert
            Assert.NotNull(result);
        }
    }
}