using System;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NumberOfPermutations("AAABBAC"));
        }


        public static Int32 NumberOfPermutations(string input)
        {
            var charNumbers = input.GroupBy(x => x, (c, enumerable) => enumerable.Count());
            
            var multiplicationFactorials = 1;
            foreach (Int32 charNumber in charNumbers)
            {
                multiplicationFactorials *= Factorial(charNumber);
            }

            return Factorial(input.Length) / multiplicationFactorials;
        }

        public static Int32 Factorial(Int32 n)
        {
            Int32 result = 1;
            for (Int32 i = 0; i < n; i++)
            {
                result *= (i + 1);
            }

            return result;
        }
    }
}