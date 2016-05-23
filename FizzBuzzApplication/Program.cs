using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzApplication
{
    public class FizzBuzz
    {
        /// <summary>
        /// Main. 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            StaticFizzBuzz();
            Console.ReadKey();
        }

        /// <summary>
        /// The typical fizz-buzz use case. 
        /// </summary>
        public static void StaticFizzBuzz()
        {
            int[] _array = Enumerable.Range(1, 100).ToArray();
            Dictionary<int, string> _pairs = new Dictionary<int, string>()
            {
                { 3, "Fizz"}, { 5, "Buzz"}, { 7, "Hello"}, { 11, "Goodbye"}
            };
            CustomFizzBuzz(_pairs, _array);
        }

        /// <summary>
        /// Print custom number/string pairs. 
        /// </summary>
        /// <param name="dict"> key/pair association of numbers and strings </param>
        /// <param name="range"> the range of numbers to iterate over. </param>
        public static void CustomFizzBuzz(Dictionary<int, string> dict, int[] range)
        {
            if (dict.Count <= 0)
            {
                throw new ArgumentException("Please include a valid dictionary.");
            }

            if (range.Length <= 0)
            {
                throw new ArgumentException("No valid range.");
            }


            foreach (int n in range)
            {
                PrintNumberToConsole(n);
                foreach (var pair in dict)
                {
                    PrintKeyIfDivisible(n, pair);
                }
                Console.Write('\n');
            }
        }

        public static void PrintNumberToConsole(int n)
        {
            try
            {
                Console.Write(" " + n.ToString() + ":");
            }
            catch (Exception e)
            {
                Trace.Write(e.Message);
            }
        }

        public static void PrintKeyIfDivisible(int n, KeyValuePair<int, string> pair)
        {
            if (n < 0)
            {
                throw new ArgumentException("The range operand is less than zero!");
            }

            if (pair.Key < 0)
            {
                throw new ArgumentException("The key operand is less than zero!");
            }

            if (pair.Value == null)
            {
                throw new ArgumentException("The printable value is null!");
            }

            if (n % pair.Key == 0)
            {
                Console.Write(" " + pair.Value);
            }
        }

    }
}
