namespace Assignment_1
{
    public class WorkingWithList
    {
        public static List<Member> GetListMembersByYear(List<Member> members, int year, char v)
        {
            List<Member> memberAfterFilter = new List<Member>();
            foreach (Member member in members)
            {
                if (v == '=' && member.DateOfBirth.Year == year)
                {
                    memberAfterFilter.Add(member);
                }
                else if (v == '>' && member.DateOfBirth.Year > year)
                {
                    memberAfterFilter.Add(member);
                }
                else if (v == '<' && member.DateOfBirth.Year < year)
                {
                    memberAfterFilter.Add(member);
                }
            }
            return memberAfterFilter;
        }

        public static Member GetTheFirstMemberByBirthPlace(List<Member> members, string? place)
        {
            foreach (Member member in members)
            {
                if (place.ToLower().Equals(member.BirthPlace.ToLower()))
                    return member;
            }
            return null;
        }

        public static Member GetOldestMember(List<Member> members)
        {
            Member oldestMember = members[0];
            for (int i = 0; i < members.Count; i++)
            {
                if (members[i].DateOfBirth < oldestMember.DateOfBirth)
                {
                    oldestMember = members[i];
                }
                else if (members[i].DateOfBirth == oldestMember.DateOfBirth)
                {
                    if (members[i].FirstName.CompareTo(oldestMember.FirstName) < 0)
                    {
                        oldestMember = members[i];
                    }
                    else if (members[i].FirstName.CompareTo(oldestMember.FirstName) == 0)
                    {
                        if (members[i].LastName.CompareTo(oldestMember.LastName) < 0)
                        {
                            oldestMember = members[i];
                        }
                    }
                }
            }
            return oldestMember;
        }

        public static List<Member> GetListMembersByGender(List<Member> members, string gender)
        {
            List<Member> memberAfterFilter = new List<Member>();
            foreach (Member member in members)
            {
                if (member.Gender.ToLower().Equals(gender.ToLower()))
                {
                    memberAfterFilter.Add(member);
                }
            }
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