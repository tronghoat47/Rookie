using ProjectStructure.Domain;
using ProjectStructure.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStructure.Repository.IRepository
{
    public interface IPersonRepository
    {
        List<Person> GetPeople();
        Person GetPersonById(Guid id);
        Person AddPerson(Person person);
        Person UpdatePerson(Person person);
        Person DeletePerson(Guid id);
    }
}
