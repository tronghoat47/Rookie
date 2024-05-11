using Assignment_2_PrimeNumberAsync;

internal class Program
{
    private static async Task Main(string[] args)
    {
        int lowerBound = ValidateValue.ValidateLowerBound();
        int upperBound = ValidateValue.ValidateUpperBound(lowerBound);

        List<int> primes = await PrimeHandling.FindPrimesInRangeAsync(lowerBound, upperBound);
        Console.WriteLine($"Prime numbers between {lowerBound} and {upperBound}: {string.Join(", ", primes)}");
    }
}