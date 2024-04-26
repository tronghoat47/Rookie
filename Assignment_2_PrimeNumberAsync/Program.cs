using Assignment_2_PrimeNumberAsync;
using Common;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading.Tasks;

class Program
{
    

    static async Task Main(string[] args)
    {
        int lowerBound = ValidateValue.ValidateLowerBound();
        int upperBound = ValidateValue.ValidateUpperBound(lowerBound);

        List<int> primes = await PrimeHandling.FindPrimesInRangeAsync(lowerBound, upperBound);
        Console.WriteLine($"Prime numbers between {lowerBound} and {upperBound}: {string.Join(", ", primes)}");
    }
}
