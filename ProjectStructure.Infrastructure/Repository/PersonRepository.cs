using ProjectStructure.Domain;
using ProjectStructure.Domain.DataAccess;
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
        private readonly DummyDataDB _dummyDataDB;
        public PersonRepository(DummyDataDB dummyDataDB)
        {
            _dummyDataDB = dummyDataDB;
        }
        public List<Person> GetPeople()
        {
            return _dummyDataDB.GetDummyPersons();
        }
    }
}
