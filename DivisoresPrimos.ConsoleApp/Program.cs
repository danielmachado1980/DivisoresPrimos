using System;
using System.Collections.Generic;

namespace DivisoresPrimos
{
   
    class Program
    {
        static void Main()
        {
            Console.Write("Digite um número: ");
            int input = int.Parse(Console.ReadLine());

            List<int> divisorNumbers = DivisorHelper.GetDivisor(input);
            List<int> primeNumbers = DivisorHelper.GetPrimeDivisor(divisorNumbers);

            Console.WriteLine($"Número de Entrada: {input}");
            Console.WriteLine("Números divisores: " + string.Join(" ", divisorNumbers));
            Console.WriteLine("Divisores Primos: " + string.Join(" ", primeNumbers));
        }
    }
}
