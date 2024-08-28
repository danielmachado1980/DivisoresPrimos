namespace DivisoresPrimos.Infra.Contracts
{
    public interface INumberServices
    {
        public List<int> GetDivisors(int number);
        public List<int> GetPrimeDivisors(List<int> divisors);
        public bool IsPrime(int number);
    }
}