using ProjectStructure.Domain;
using ProjectStructure.Domain.DataAccess;
using ProjectStructure.Domain.Models;
using ProjectStructure.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStructure.Repository.Repository
{
    public class PersonRepository : IPersonRepository
    {
        public List<Person> GetPeople()
        {
            return DummyDataDB.ListPeople;
        }
        public Person GetPersonById(Guid id)
        {
            return DummyDataDB.ListPeople.Find(x => x.Id == id);
        }
        public Person AddPerson(Person person)
        {
            DummyDataDB.ListPeople.Add(person);
            return person;
        }
        public Person UpdatePerson(Person person)
        {
            var personToUpdate = DummyDataDB.ListPeople.Find(x => x.Id == person.Id);
            if (personToUpdate != null)
            {
                personToUpdate.FirstName = person.FirstName;
                personToUpdate.LastName = person.LastName;
                personToUpdate.Gender = person.Gender;
                personToUpdate.DateOfBirth = person.DateOfBirth;
                personToUpdate.PhoneNumber = person.PhoneNumber;
                personToUpdate.BirthPlace = person.BirthPlace;
                personToUpdate.IsGraduated = person.IsGraduated;
            }
            return personToUpdate;
        }
        public Person DeletePerson(Guid id)
        {
            var personToDelete = DummyDataDB.ListPeople.Find(x => x.Id == id);
            if (personToDelete != null)
            {
                DummyDataDB.ListPeople.Remove(personToDelete);
            }
            return personToDelete;
        }
    }
}
