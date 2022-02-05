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

        //calculating all passible numbers
        static List<int> GetPossibleValues(int input)
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

        //
        static List<int> LagrangeFactor(int value)
        {
            List<int> possibleValues = GetPossibleValues(value);
            possibleValues.Sort((a, b) => a >= b ? -1 : 1);

            int initialThreshold = (int)Math.Sqrt(value);
            List<int> result = Factor(value, possibleValues.Where(v=>v <= initialThreshold));
            while (result.Count > 4)
            {
                initialThreshold--;
                result = Factor(value, possibleValues.Where(v => v <= initialThreshold));
            }

            while(result.Count < 4)
            {
                result.Add(0);
            }
            return result;
        }

        //factorize uising threshold
        static List<int> Factor(int value, IEnumerable<int> possibleValues)
        {
            List<int> result = new List<int>();
            while (value > 0)
            {
                int appropriate = FindNextAppropriate(value, possibleValues);
                result.Add(appropriate);
                value -= appropriate * appropriate;
            }
            return result;
        }

        //getting the next number which is less than threshold
        static int FindNextAppropriate(int value, IEnumerable<int> input)
        {
            foreach (int i in input)
            {
                if (i * i <= value)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
