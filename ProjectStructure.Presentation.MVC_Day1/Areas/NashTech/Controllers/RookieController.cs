using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectStructure.Domain;
using ProjectStructure.Domain.Enums;
using ProjectStructure.Domain.Models;
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
            ViewBag.Message = TempData["Message"];
            ViewBag.Error = TempData["Error"];

            //var result = _rookieService.GetStringResult(people, false);

            //return Content(result);
            return View(people);
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
        public IActionResult Add()
        {
            //using enum GenderType to add to select tag
            ViewBag.GenderTypes = new SelectList(Enum.GetValues(typeof(GenderType)));
            return View(new Person());
        }
        [HttpPost]
        public IActionResult Add(Person person)
        {
            ViewBag.GenderTypes = new SelectList(Enum.GetValues(typeof(GenderType)));
            if (ModelState.IsValid)
            {
                Person personReturned = _rookieService.AddPerson(person);
                if (personReturned != null)
                {
                    //I want to Index has a message success
                    TempData["Message"] = "Add success";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Add failed";
                    return View(person);
                }
            }
            return View(person);
        }
        public IActionResult Detail(Guid id)
        {
            var person = _rookieService.GetPersonById(id);
            ViewBag.GenderTypes = Enum.GetValues(typeof(GenderType));
            return View(person);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var person = _rookieService.GetPersonById(id);
            if(person == null)
            {
                TempData["Error"] = "Person not found";
                return RedirectToAction("Index");
            }
            ViewBag.GenderTypes = Enum.GetValues(typeof(GenderType));
            return View(person);
        }

        [HttpPost]
        public IActionResult Edit(Person person)
        {
            ViewBag.GenderTypes = Enum.GetValues(typeof(GenderType));
            if (ModelState.IsValid)
            {
                Person personReturned = _rookieService.UpdatePerson(person);
                if (personReturned != null)
                {
                    TempData["Message"] = "Update success";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Update failed";
                    return RedirectToAction("Edit", person.Id);
                }
            }
            return View(person);
        }
        public IActionResult Delete(Guid id)
        {
            return View();
        }

    }
}
