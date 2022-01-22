using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagrangeTheoremForNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int n;
            bool iscorrectNumber = int.TryParse(input, out n);
            if (iscorrectNumber)
            {
                foreach (var v in LagrangeFactor(n))
                {
                    Console.WriteLine(v);
                }
            }

            Console.Read();
        }

        //
        static List<int> LagrangeFactor(int value)
        {
            int initialThreshold = (int)Math.Sqrt(value);
            List<int> result = Factor(value, initialThreshold);
            while (result.Count > 4)
            {
                initialThreshold--;
                result = Factor(value, initialThreshold);
            }
            return result;
        }

        //factorize uising threshold
        static List<int> Factor(int value, int initialThreshold)
        {
            List<int> result = new List<int>();
            List<int> values = GetValues(value);
            values.Sort((a, b) => a >= b ? -1 : 1);
            while (value > 0)
            {
                int appropriate = FindNextAppropriate(value, values, initialThreshold);
                result.Add(appropriate);
                value -= appropriate * appropriate;
            }
            return result;
        }

        //calculating all passible numbers
        static List<int> GetValues(int input)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < input; i++)
            {
                if (i * i <= input)
                {
                    result.Add(i);
                }
            }
            return result;
        }

        //getting the next number which is less than threshold
        static int FindNextAppropriate(int value, IEnumerable<int> input, int threshhold)
        {
            foreach (int i in input)
            {
                if (i <= threshhold && (i * i <= value))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
