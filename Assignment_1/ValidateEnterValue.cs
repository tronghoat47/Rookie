using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class ValidateEnterValue
    {
        public static int EnterInt()
        {
            int number;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out number))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter an integer.");
                }
            }
        }

        public static DateOnly EnterDate()
        {
            DateOnly date;
            while (true)
            {
                if (DateOnly.TryParse(Console.ReadLine(), out date))
                {
                    return date;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a date.");
                }
            }
        }

        public static string EnterPhoneNumber()
        {
            string phoneNumber;
            while (true)
            {
                phoneNumber = Console.ReadLine();
                if (Regex.IsMatch(phoneNumber, Constants.PATTERN_PHONE_NUMBER))
                {
                    return phoneNumber;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a 10-digit phone number.");
                }
            }
        }

        public static string EnterGender()
        {
            string gender;
            while (true)
            {
                gender = Console.ReadLine().ToLower();
                if (gender.Equals(Constants.GENDER_FEMALE) || gender.Equals(Constants.GENDER_MALE))
                {
                    return gender;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter \"male\" or \"female\".");
                }
            }
        }

        public static bool EnterTrueFalse()
        {
            string input;
            while (true)
            {
                input = Console.ReadLine();
                if (input.ToLower().Equals("true") || input.ToLower().Equals("false") || input.ToLower().Equals("1") || input.ToLower().Equals("0"))
                {
                    return bool.Parse(input);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter \"true\" or \"false\" - \"1\" or \"0\".");
                }
            }
        }

    }
}
