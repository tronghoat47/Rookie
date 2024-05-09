using ProjectStructure.Domain;
using ProjectStructure.Domain.Enums;
using ProjectStructure.Domain.Models;
using ProjectStructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStucture.Application.Services.Interfaces
{
    public interface IRookieService
    {
        List<Person> GetPeople();
        string GetStringResult(List<Person> people, bool isCombinedName);
        List<Person> GetPeopleByGender(string gender);
        Person GetOldestPerson();
        List<Person> FilterByBirthYear(int year, string comparison);
        Person AddPerson(Person person);
        Person UpdatePerson(Person person);
        Person DeletePerson(Guid id);
        Person GetPersonById(Guid id);
        List<Person> FilterPeople(string name, GenderType gender, string birthPlace);
        List<Person> FilterPeople(string name, string birthPlace);
    }
}
