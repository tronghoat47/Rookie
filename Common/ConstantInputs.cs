using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    internal class ConstantInputs
    {
        public const string PATTERN_PHONE_NUMBER = @"^\d{10}$";
        public const string GENDER_MALE = "male";
        public const string GENDER_FEMALE = "female";
        public const int MAX_ENTER_INVALID_TIMES = 3;
        public const string ERROR_MESSAGE = "You have entered invalid input too many times.";
    }
}
