using Assignment_MVC_Day1.Models;

namespace Assignment_MVC_Day1.Common
{
    public class PersonUtils
    {
        public string GetResult(List<Person> persons, bool isCombinedName)
        {
            string result = "-------------------------------------\n";
            if (persons.Count == 0)
            {
                result += "No person found\n";
            }
            else
            {
                result += $"Total persons: {persons.Count}\n" +
                    $"---------------------------------------\n";
                foreach (Person person in persons)
                {
                    if (!isCombinedName)
                    {
                        result += $"First Name: {person.FirstName}\n" +
                            $"Last Name: {person.LastName}\n";
                    }
                    else
                    {
                        result += $"Full Name: {person.LastName} {person.FirstName}\n";
                    }
                    result += $"Gender: {person.Gender}\n";
                    result += $"Phone Number: {person.PhoneNumber}\n" +
                        $"Date of Birth: {person.DateOfBirth}\n" +
                        $"Place of Birth: {person.BirthPlace}\n" +
                        $"Age: {(DateTime.Now.Year - person.DateOfBirth.Year)}\n" +
                        $"Is Graduated: {person.IsGraduated}\n" +
                        $"-------------------------------------------\n";
                }
            }
            return result;
        }
        public List<Person> GetPersonByGender(List<Person> persons, string gender)
        {
            List<Person> result = persons.Where(p => p.Gender.ToString() == gender).ToList();
            return result;
        }
        public Person GetTheOldestPerson(List<Person> persons)
        {
            Person result = persons.OrderBy(p => p.DateOfBirth).FirstOrDefault();
            return result;
        }
        public List<Person> GetPersonByYearOfBirth(List<Person> persons, string ope, int year)
        {
            
        } 
    }
}
