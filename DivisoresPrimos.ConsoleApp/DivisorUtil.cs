namespace DivisoresPrimos
{
    public static class DivisorHelper
    {
        public static List<int> GetDivisor(int input)
        {
            List<int> divisors= new List<int>();
            for (int i = 1; i <= input; i++)
            {
                if (input % i == 0)
                    divisors.Add(i);
            }
            return divisors;
        }

        public static List<int> GetPrimeDivisor(List<int> divisors)
        {
            List<int> primeDivisors = new List<int>();
            foreach (int divisor in divisors)
            {
                if (IsPrime(divisor))
                    primeDivisors.Add(divisor);
            }
            return primeDivisors;
        }

        public static bool IsPrime(int number)
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
