using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_PrimeNumberAsync
{
    public class PrimeHandling
    {
        private static async Task<bool> IsPrimeAsync(int n)
        {
            return await Task.Run(() =>
            {
                if (n < 2)
                    return false;
                int nSqrt = (int)Math.Sqrt(n);
                for (int i = 2; i <= nSqrt; i++)
                {
                    if (n % i == 0)
                        return false;
                }
                return true;
            });
        }

        public static async Task<List<int>> FindPrimesInRangeAsync(int a, int b)
        {
            return await Task.Run(async () =>
            {
                List<int> primes = new List<int>();
                for (int i = a; i <= b; i++)
                {
                    if (await IsPrimeAsync(i))
                        primes.Add(i);
                }
                return primes;
            });
        }
    }
}
