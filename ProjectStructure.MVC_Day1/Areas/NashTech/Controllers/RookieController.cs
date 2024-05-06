using Microsoft.AspNetCore.Mvc;
using ProjectStructure.Domain;
using ProjectStructure.Domain.Enums;
using ProjectStucture.Application.Services.Interfaces;

namespace ProjectStructure.MVC_Day1.Areas.NashTech.Controllers
{
    [Area("NashTech")]
    public class RookieController : Controller
    {
        private readonly IRookieService _rookieService;
        private readonly IExcelService _excelService;
        public RookieController(IRookieService rookieService, IExcelService excelService)
        {
            _rookieService = rookieService;
            _excelService = excelService;
        }
        public IActionResult Index()
        {
            var people = _rookieService.GetPeople();
            var result = _rookieService.GetStringResult(people, false);

            return Content(result);
        }

        public IActionResult PeopleByGender(string gender)
        {
            if (!string.IsNullOrEmpty(gender) && Enum.IsDefined(typeof(GenderType), gender))
            {
                var people = _rookieService.GetPeopleByGender(gender);
                return Content(_rookieService.GetStringResult(people, false));
            }
            return Content("gender is not valid");
        }

        public IActionResult TheOldestPerson()
        {
            var result = _rookieService.GetOldestPerson();
            return Content(_rookieService.GetStringResult(new List<Person> { result }, false));
        }

        public IActionResult PeopleWithFullName()
        {
            var result = _rookieService.GetStringResult(_rookieService.GetPeople(), true);
            return Content(result);
        }

        public IActionResult PeopleByYearOfBirth(string ope, string year)
        {
            if(!string.IsNullOrEmpty(ope) && Enum.IsDefined(typeof(ComparisionOperator), ope) && int.TryParse(year, out var value))
            {
                var people = _rookieService.FilterByBirthYear(value, ope);
                return Content(_rookieService.GetStringResult(people, false));
            }
            return Content("Invalid on query");
        }

        public IActionResult ExportToExcel()
        {
            var people = _rookieService.GetPeople();
            var file = _excelService.ExportToExcel(people);
            return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "people.xlsx");
        }
    }
}
