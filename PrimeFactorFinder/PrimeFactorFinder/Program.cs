using System;
using System.Collections.Generic;

namespace IsPrimeChecker
{
    class Program
    {
        private const int inputLimit = 100000;

        static void Main(string[] args)
        {
            Console.Title = "Prime Factor Finder";

            while (true)
            {
                Console.WriteLine("Enter number:");

                var input = Console.ReadLine();

                int number = 0;
                int.TryParse(input, out number);

                if (number != 0 && number <= inputLimit)
                {
                    List<int> primeFactors = PrimeFactorFinder.GetPrimeFactors(number);

                    Console.WriteLine("Prime Factors:");

                    foreach (var primeFactor in primeFactors)
                    {
                        Console.Write(string.Format("{0}, ", primeFactor));
                    }
                }
                else
                {
                    Console.WriteLine("Input not accepted");
                }

                Console.ReadKey();
                Console.Clear();
            }          
        }
    }

    public static class PrimeFactorFinder
    {
        public static List<int> GetPrimeFactors(int number)
        {
            List<int> primefactors = new List<int>();

            if (number < 2)
                return primefactors;

            foreach (var factor in GetFactors(number))
            {
                if (GetFactors(factor).Count == 2)
                {
                    primefactors.Add(factor);
                }
            }

            return primefactors;
        }

        private static List<int> GetFactors(int number)
        {
            List<int> factors = new List<int>() { 1 };

            if (number > 1)
                factors.Add(number);
           
            for (int i = 2; i <= number / 2; i++)
            {
                if (number % i == 0)
                    factors.Add(i);
            }

            return factors;
        }
    }
}
