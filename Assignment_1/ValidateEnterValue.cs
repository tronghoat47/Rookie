using System.Text.RegularExpressions;

namespace Assignment_1
{
    public class ValidateEnterValue
    {
        public static CustomEnterValue EnterInt()
        {
            int invalidTimes = 0;
            int number;
            while (true)
            {
                if (IsExceedMaxInvalidTimes(invalidTimes))
                {
                    return new CustomEnterValue();
                }
                if (int.TryParse(Console.ReadLine(), out number))
                {
                    return new CustomEnterValue(number);
                }
                else
                {
                    invalidTimes++;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter an integer.");
                    Console.ResetColor();
                }
            }
        }

        public static CustomEnterValue EnterDate()
        {
            int invalidTimes = 0;
            DateOnly date;
            while (true)
            {
                if (IsExceedMaxInvalidTimes(invalidTimes))
                {
                    return new CustomEnterValue();
                }
                if (DateOnly.TryParse(Console.ReadLine(), out date))
                {
                    return new CustomEnterValue(date);
                }
                else
                {
                    invalidTimes++;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a date.");
                    Console.ResetColor();
                }
            }
        }

        public static CustomEnterValue EnterPhoneNumber()
        {
            int invalidTimes = 0;
            string phoneNumber;
            while (true)
            {
                if (IsExceedMaxInvalidTimes(invalidTimes))
                {
                    return new CustomEnterValue();
                }
                phoneNumber = Console.ReadLine();
                if (Regex.IsMatch(phoneNumber, Constants.PATTERN_PHONE_NUMBER))
                {
                    return new CustomEnterValue(phoneNumber);
                }
                else
                {
                    invalidTimes++;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a 10-digit phone number.");
                    Console.ResetColor();
                }
            }
        }

        public static CustomEnterValue EnterGender()
        {
            int invalidTimes = 0;
            string gender;
            while (true)
            {
                if (IsExceedMaxInvalidTimes(invalidTimes))
                {
                    return new CustomEnterValue(); ;
                }
                gender = Console.ReadLine().ToLower();
                if (gender.Equals(Constants.GENDER_FEMALE) || gender.Equals(Constants.GENDER_MALE))
                {
                    return new CustomEnterValue(gender);
                }
                else
                {
                    invalidTimes++;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter \"male\" or \"female\".");
                    Console.ResetColor();
                }
            }
        }

        public static CustomEnterValue EnterTrueFalse()
        {
            int invalidTimes = 0;
            string input;
            while (true)
            {
                if (IsExceedMaxInvalidTimes(invalidTimes))
                {
                    return new CustomEnterValue();
                }
                input = Console.ReadLine();
                if (input.ToLower().Equals("true") || input.ToLower().Equals("false") || input.ToLower().Equals("1") || input.ToLower().Equals("0"))
                {
                    return new CustomEnterValue(bool.Parse(input));
                }
                else
                {
                    invalidTimes++;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter \"true\" or \"false\" - \"1\" or \"0\".");
                    Console.ResetColor();
                }
            }
        }

        private static bool IsExceedMaxInvalidTimes(int invalidTimes)
        {
            return invalidTimes == Constants.MAX_ENTER_INVALID_TIMES;
        }
    }
}