using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_LinQ
{
    public class Print
    {
        public static void Menu(List<Member> members)
        {
            while (true)
            {
                Console.Write("-------------------Welcome to the Filter Member System--------------------\n\n" +
                    "0: Add a new Member\n" +
                    "1: Get the list Members by gender\n" +
                    "2: Get the oldest Member\n" +
                    "3: Get the list Members combined FirstName & LastName\n" +
                    "4: Get 3 lists Members has birth year equal, greater than, less than a year\n" +
                    "5: Enter the palce. Then get the first Member who was born this palce\n" +
                    "6: Get the list all members\n" +
                    "7: Clear console\n" +
                    "8: Exit the system\n" +
                    "Choose a option from 0->8: ");
                CustomEnterValue choiceValue = ValidateEnterValue.EnterInt();
                if (choiceValue.Value == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(choiceValue.Message);
                    Console.ResetColor();
                }
                else
                {
                    switch (choiceValue.Value)
                    {
                        case 0:
                            {
                                WorkingWithList.AddNewMember(members);
                                Console.WriteLine("Add a new member successfully");
                                break;
                            }
                        case 1:
                            {
                                Console.Write("Enter gender 'Male' or 'Female': ");
                                CustomEnterValue genderValue = ValidateEnterValue.EnterGender();
                                if (genderValue.Value == null)
                                {
                                    Console.WriteLine(genderValue.Message);
                                    break;
                                }
                                List<Member> memberByGender = WorkingWithList.GetListMembersByGender(members, genderValue.Value);
                                Console.WriteLine($"Total members: {memberByGender.Count()}");
                                PrintResult(memberByGender, false);
                                break;
                            }
                        case 2:
                            {
                                Member oldestMember = WorkingWithList.GetOldestMember(members);
                                PrintResult(new List<Member> { oldestMember }, false);
                                break;
                            }
                        case 3:
                            {
                                PrintResult(members, true);
                                break;
                            }
                        case 4:
                            {
                                Console.Write("Enter the year: ");
                                CustomEnterValue yearValue = ValidateEnterValue.EnterInt();
                                if (yearValue.Value == null)
                                {
                                    Console.WriteLine(yearValue.Message);
                                    break;
                                }
                                SubMenu(members, yearValue.Value);
                                break;
                            }
                        case 5:
                            {
                                Console.Write("Enter the place: ");
                                string place = Console.ReadLine();
                                Member memberByPlace = WorkingWithList.GetTheFirstMemberByBirthPlace(members, place.Trim());
                                if (memberByPlace == null)
                                {
                                    Console.WriteLine("No result found.");
                                    break;
                                }
                                PrintResult(new List<Member> { memberByPlace }, false);
                                break;
                            }
                        case 6:
                            {
                                PrintResult(members, false);
                                break;
                            }
                        case 7:
                            {
                                Console.Clear();
                                break;
                            }
                        case 8:
                            {
                                Console.WriteLine("Exit the system");
                                return;
                            }
                        default:
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid input. Please enter a number from 0 to 8.");
                                Console.ResetColor();
                                break;
                            }
                    }
                }
            }
        }

        public static void SubMenu(List<Member> members, int year)
        {
            while (true)
            {
                Console.Write($"1: Get list members has birth year is {year}\n" +
                    $"2: Get list members who has birth yeaer greater than {year}\n" +
                    $"3: Get list members who has birth year less than {year}\n" +
                    $"0: Exit this filter\n" +
                    $"Choose an option from 0->3: ");
                CustomEnterValue choiceValue = ValidateEnterValue.EnterInt();
                if (choiceValue.Value == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(choiceValue.Message);
                    Console.ResetColor();
                }
                else
                {
                    switch (choiceValue.Value)
                    {
                        case 1:
                            {
                                List<Member> memberByYear = WorkingWithList.GetListMembersByYear(members, year, '=');
                                Console.WriteLine($"Total members: {memberByYear.Count()}");
                                PrintResult(memberByYear, false);
                                break;
                            }
                        case 2:
                            {
                                List<Member> memberByYear = WorkingWithList.GetListMembersByYear(members, year, '>');
                                Console.WriteLine($"Total members: {memberByYear.Count()}");
                                PrintResult(memberByYear, false);
                                break;
                            }
                        case 3:
                            {
                                List<Member> memberByYear = WorkingWithList.GetListMembersByYear(members, year, '<');
                                Console.WriteLine($"Total members: {memberByYear.Count()}");
                                PrintResult(memberByYear, false);
                                break;
                            }
                        case 0:
                            {
                                Console.WriteLine("Exit filter year");
                                return;
                            }
                        default:
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid input. Please enter a number from 1 to 3.");
                                Console.ResetColor();
                                break;
                            }
                    }
                }
            }
        }

        public static void PrintResult(List<Member> members, bool isCombinedName)
        {
            string result = "-------------------------------------\n";
            if (members.Count == 0)
            {
                Console.WriteLine("No result found.");
            }
            else
            {
                foreach (Member member in members)
                {
                    if (!isCombinedName)
                    {
                        result += $"First Name: {member.FirstName}\n" +
                            $"Last Name: {member.LastName}\n";
                    }
                    else
                    {
                        result += $"Full Name: {member.LastName} {member.FirstName}\n";
                    }
                    result += $"Gender: {member.Gender}\n";
                    result += $"Phone Number: {member.PhoneNumber}\n" +
                        $"Date of Birth: {member.DateOfBirth}\n" +
                        $"Place of Birth: {member.BirthPlace}\n" +
                        $"Age: {member.Age}\n" +
                        $"Is Graduated: {member.IsGraduated}\n" +
                        $"-------------------------------------------\n";
                }
            }
            Console.WriteLine(result);
        }
    }
}
