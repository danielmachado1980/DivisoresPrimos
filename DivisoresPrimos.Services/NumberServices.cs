using DivisoresPrimos.Infra.Contracts;
using Microsoft.Extensions.Caching.Memory;

namespace DivisoresPrimos.Services
{
    public class NumberServices : INumberServices
    {
        private readonly IMemoryCache _cache;

        public NumberServices(IMemoryCache cache)
        {
            _cache = cache;
        }

        public List<int> GetDivisors(int input)
        {
            return _cache.GetOrCreate($"Divisors_{input}", entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
                List<int> divisors = new List<int>();
                for (int i = 1; i <= input; i++)
                {
                    if (input % i == 0)
                        divisors.Add(i);
                }
                return divisors;
            });
        }

        public List<int> GetPrimeDivisors(List<int> divisors)
        {
            return _cache.GetOrCreate($"Divisors_{string.Join("_", divisors)}", entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);

                List<int> primeDivisors = new List<int>();
                foreach (int divisor in divisors)
                {
                    if (IsPrime(divisor))
                        primeDivisors.Add(divisor);
                }
                return primeDivisors;
            });
        }

        public bool IsPrime(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
    }
}