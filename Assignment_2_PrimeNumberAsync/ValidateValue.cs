using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_PrimeNumberAsync
{
    public class ValidateValue
    {
        public static int ValidateLowerBound()
        {
            CustomEnterValue lowerBound;
            while (true)
            {
                Console.Write("Enter the lower bound: ");
                lowerBound = ValidateEnterValue.EnterInt();
                if (lowerBound.Value == null)
                {
                    Console.WriteLine(lowerBound.Message);
                }
                else
                {
                    break;
                }
            }
            return lowerBound.Value;
        }
        public static int ValidateUpperBound(int lowerBound)
        {
            CustomEnterValue upperBound;
            while (true)
            {
                Console.Write("Enter the upper bound: ");
                upperBound = ValidateEnterValue.EnterInt();
                if (upperBound.Value == null)
                {
                    Console.WriteLine(upperBound.Message);
                }
                else if (upperBound.Value <= lowerBound)
                {
                    Console.WriteLine("The upper bound must be greater than the lower bound.");
                }
                else
                {
                    break;
                }
            }
            return upperBound.Value;
        }
    }
}
