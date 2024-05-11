using Common;

namespace Assignment_2_LinQ
{
    public class WorkingWithList
    {
        public static List<Member> GetListMembersByYear(List<Member> members, int year, char v)
        {
            List<Member> memberAfterFilter = new List<Member>();
            if (members == null || members.Count == 0)
            {
                return memberAfterFilter;
            }
            memberAfterFilter = members.Where(member => v == '=' && member.DateOfBirth.Year == year
                                                    || v == '>' && member.DateOfBirth.Year > year
                                                    || v == '<' && member.DateOfBirth.Year < year)
                                    .ToList();
            return memberAfterFilter;
        }

        public static Member GetTheFirstMemberByBirthPlace(List<Member> members, string place = "")
        {
            if (members == null || members.Count == 0)
            {
                return null;
            }
            return members.FirstOrDefault(member => place.ToLower().Equals(member.BirthPlace.ToLower()));
        }

        public static Member GetOldestMember(List<Member> members)
        {
            if (members == null || members.Count == 0)
            {
                return null;
            }
            Member oldestMember = members.OrderBy(member => member.DateOfBirth)
                .ThenBy(member => member.FirstName)
                    .ThenBy(member => member.LastName)
                    .First();
            return oldestMember;
        }

        public static List<Member> GetListMembersByGender(List<Member> members, string gender)
        {
            if (members == null || members.Count == 0)
            {
                return new List<Member>();
            }
            List<Member> memberAfterFilter = members.Where(members => members.Gender.ToLower().Equals(gender.ToLower())).ToList();
            return memberAfterFilter;
        }

        public static void AddNewMember(List<Member> members)
        {
            Console.WriteLine("Enter the information of the new member:");
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Gender(male/female): ");
            CustomEnterValue gender = ValidateEnterValue.EnterGender();
            if (gender.Value == null)
            {
                Console.WriteLine(gender.Message);
                return;
            }
            Console.Write("Date of Birth(yyyy/mm/DD): ");
            CustomEnterValue dateOfBirth = ValidateEnterValue.EnterDate();
            if (dateOfBirth.Value == null)
            {
                Console.WriteLine(dateOfBirth.Message);
                return;
            }
            Console.Write("Phone Number(10 digits): ");
            CustomEnterValue phoneNumber = ValidateEnterValue.EnterPhoneNumber();
            if (phoneNumber.Value == null)
            {
                Console.WriteLine(phoneNumber.Message);
                return;
            }
            Console.Write("Birth Place: ");
            string birthPlace = Console.ReadLine();
            Console.Write("Is Graduated(true/false): ");
            CustomEnterValue isGraduated = ValidateEnterValue.EnterTrueFalse();
            if (isGraduated.Value == null)
            {
                Console.WriteLine(isGraduated.Message);
                return;
            }
            members.Add(new Member(firstName, lastName, gender.Value, dateOfBirth.Value, phoneNumber.Value, birthPlace, isGraduated.Value));
        }
    }
}