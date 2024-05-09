using API_Assignment_Day2.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectStructure.Domain.Enums;
using ProjectStructure.Domain.Models;
using ProjectStucture.Application.Services.Interfaces;

namespace API_Assignment_Day2.Controllers
{
    [ApiController]
    [Route("api/persons")]
    public class PersonController : Controller
    {
        private readonly IRookieService _rookieService;

        public PersonController(IRookieService rookieService)
        {
            _rookieService = rookieService;
        }
        [HttpGet]
        //[Authorize(Roles = "user")]
        public IActionResult GetPersons()
        {
            var persons = _rookieService.GetPeople();
            if (persons.Count == 0)
                return NotFound("Don't have any person");
            return Ok(persons.ConvertAll(person => new PersonResponse(person)));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Id is type of Guid</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        //[Authorize(Roles = "user")]
        public IActionResult GetPerson(Guid id)
        {
            var person = _rookieService.GetPersonById(id);
            if(person == null)
                return NotFound("Person not found");
            return Ok(new PersonResponse(person));
        }
        [HttpPost]
        //[Authorize(Roles = "admin")]
        public IActionResult AddPerson(PersonRequest personRequest)
        {
            var person = new Person
            {
                FirstName = personRequest.FirstName,
                LastName = personRequest.LastName,
                Gender = (GenderType)Enum.Parse(typeof(GenderType), personRequest.Gender, true),
                DateOfBirth = DateOnly.Parse(personRequest.DateOfBirth),
                PhoneNumber = personRequest.PhoneNumber,
                BirthPlace = personRequest.BirthPlace,
                IsGraduated = personRequest.IsGraduated
            };
            var addedPerson = _rookieService.AddPerson(person);
            if(addedPerson == null)
                return BadRequest("Add person failed");
            return Ok(new PersonResponse(addedPerson));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Id is type of Guid</param>
        /// <param name="personRequest"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        //[Authorize(Roles = "admin")]
        public IActionResult UpdatePerson(Guid id, PersonRequest personRequest)
        {
            var person = new Person
            {
                Id = id,
                FirstName = personRequest.FirstName,
                LastName = personRequest.LastName,
                Gender = (GenderType)Enum.Parse(typeof(GenderType), personRequest.Gender, true),
                DateOfBirth = DateOnly.Parse(personRequest.DateOfBirth),
                PhoneNumber = personRequest.PhoneNumber,
                BirthPlace = personRequest.BirthPlace,
                IsGraduated = personRequest.IsGraduated
            };
            var updatedPerson = _rookieService.UpdatePerson(person);
            if(updatedPerson == null)
                return BadRequest("Update person failed");
            return Ok(new PersonResponse(updatedPerson));
        }
        
        /// <summary>
        ///     Delete person by id
        /// </summary>
        /// <param name="id">Id is type of Guid</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        //[Authorize(Roles = "admin")]
        public IActionResult DeletePerson(Guid id)
        {
            var person = _rookieService.DeletePerson(id);
            if(person == null)
                return BadRequest("Delete person failed");
            return Ok(new PersonResponse(person));
        }

        [HttpPost("filter")]
        public IActionResult FilterPerson([FromForm] ObjectPersonFilter objectFilter)
        {
            string name = string.IsNullOrEmpty(objectFilter.Name) ? "" : objectFilter.Name;
            string birthPlace = string.IsNullOrEmpty(objectFilter.BirthPlace) ? "" : objectFilter.BirthPlace;
            if(string.IsNullOrEmpty(objectFilter.Gender))
                return Ok(_rookieService.FilterPeople(name, birthPlace).ConvertAll(person => new PersonResponse(person)));
            var genderGenderType = (GenderType)Enum.Parse(typeof(GenderType), objectFilter.Gender, true);
            var persons = _rookieService.FilterPeople(name, genderGenderType, birthPlace);
            if(persons == null)
                return NotFound("Person not found");
            return Ok(persons.ConvertAll(person => new PersonResponse(person)));
        }
    }
}
