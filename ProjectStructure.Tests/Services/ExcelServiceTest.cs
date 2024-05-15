using ProjectStructure.Domain.Models;
using ProjectStucture.Application.Services;
using ProjectStucture.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjectStructure.Tests.Services
{
    public class ExcelServiceTest
    {
        private readonly IExcelService _excelService;

        public ExcelServiceTest()
        {
            _excelService = new ExcelService();
        }

        [Fact]
        public void ExportToExcelTest()
        {
            // Arrange
            var people = new List<Person>
            {
                new Person
                {
                    FirstName = "John",
                    LastName = "Doe",
                },
                new Person
                {
                    FirstName = "Jane",
                    LastName = "Doe",
                },
            };

            // Act
            var result = _excelService.ExportToExcel(people);

            // Assert
            Assert.NotNull(result);
        }
    }
}