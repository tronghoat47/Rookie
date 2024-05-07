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
        public IActionResult Index(int page = 1, int pageSize = 2)
        {
            var people = _rookieService.GetPeople()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            ViewBag.Message = TempData["Message"];
            ViewBag.Error = TempData["Error"];
            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = Math.Ceiling((double)_rookieService.GetPeople().Count() / pageSize);

            return View(people);
        }

        public IActionResult PeopleByGender(string gender, bool firstLoad)
        {
            if (!string.IsNullOrEmpty(gender) && Enum.IsDefined(typeof(GenderType), gender))
            {
                var people = _rookieService.GetPeopleByGender(gender);
                if (firstLoad)
                    return View(people);
                if (people.Count == 0)
                {
                    ViewBag.Error = "No person found";
                    return PartialView("_TablePeople", new List<Person>());
                }
                return PartialView("_TablePeople", people);
            }
            ViewBag.Error = "Gender is not valid";
            return PartialView("_TablePeople", new List<Person>());
        }

        public IActionResult TheOldestPerson()
        {
            var person = _rookieService.GetOldestPerson();
            if (person == null)
            {
                return RedirectToAction("Detail");
            }
            return RedirectToAction("Detail", new { id = person.Id });

        }

        public IActionResult PeopleWithFullName()
        {
            var people = _rookieService.GetPeople().Select(p => new
            {
                Id = p.Id,
                FullName = p.FirstName + " " + p.LastName,
                Gender = p.Gender,
                DateOfBirth = p.DateOfBirth,
                PhoneNumber = p.PhoneNumber,
                BirthPlace = p.BirthPlace,
                IsGraduated = p.IsGraduated
            });
            if (people.Count() == 0)
            {
                ViewBag.IsNoElement = "No person found";
                return View();
            }
            return View(people);
        }

        public IActionResult PeopleByYearOfBirth(string ope, string year, bool firstLoad)
        {
            if (!string.IsNullOrEmpty(ope) && Enum.IsDefined(typeof(ComparisionOperator), ope) && int.TryParse(year, out var value))
            {
                var people = _rookieService.FilterByBirthYear(value, ope);
                ViewBag.Year = year;
                if (firstLoad)
                    return View(people);

                if (people.Count == 0)
                {
                    ViewBag.IsNoElement = "No person found";
                    return PartialView("_TablePeople", new List<Person>());
                }
                return PartialView("_TablePeople", people);
            }
            ViewBag.Error = "Invalid input";
            return PartialView("_TablePeople", new List<Person>());
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
            if (person == null)
            {
                ViewBag.Error = "Person not found";
                return View();
            }
            ViewBag.GenderTypes = Enum.GetValues(typeof(GenderType));
            return View(person);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var person = _rookieService.GetPersonById(id);
            if (person == null)
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
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var result = _rookieService.DeletePerson(id);
            if (result != null)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }

    }
}
